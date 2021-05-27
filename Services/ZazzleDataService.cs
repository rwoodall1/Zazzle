using ApiBindingModels;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using Utilities;
using RESTModule;
using System.Text.Json;
using NLog;
using Core;
using System;
using System.Collections.Generic;
using SQLClient;
using Hangfire;
namespace Services
{
    public class ZazzleDataService : BaseDataService
    {
        public async Task<ApiProcessingResult> ListNewOrders()
        {

            var processingResult = new ApiProcessingResult();
            var baseUrl = ApplicationConfig.ZazzleRootUrl.ToString();
            var vendorId = ApplicationConfig.VendorId.ToString();
            var secretKey = ApplicationConfig.SecretKey.ToString();
            string hash = Utils.Encrypt(vendorId + secretKey);
            string endPoint = baseUrl + "method=listneworders&vendorid=" + vendorId + "&hash=" + hash;
            var restServiceResult = await new RESTService().MakeRESTCall("GET", "data", "content-type", endPoint);
            if (restServiceResult.IsError)
            {
                log.Error("ListNewOrders REST Error:" + restServiceResult.Errors[0].ErrorMessage);
            }
            if (restServiceResult.Data.APIResult != null && restServiceResult.Data.APIResult.ToString().Contains("SUCCESS"))
            {
                try
                {
                    var vData = Serialize.FromXml<Response>(restServiceResult.Data.APIResult);
                    ProcessOrders(vData);
                }
                catch (Exception ex)
                {
                    this.log.Error("ListNewOrder Error Serializing text to object():" + ex.Message);
                    processingResult.IsError = true;
                    new EmailHelper().SendEmail("ListNewOrder() Error", ApplicationConfig.ErrorEmailAddress.ToString(), "", "ListNewOrder Error Serializing text to object():" + ex.Message);
                    return processingResult;
                }
            }
            return processingResult;
        }
        public async Task<ApiProcessingResult> ProcessOrders(Response model)
        {
            var processingResult = new ApiProcessingResult();
            var sqlClient = new SQLCustomClient();
            var sqlClientDetail = new SQLCustomClient();
            var sqlClientFile = new SQLCustomClient();
            sqlClient.CommandText(@"Insert INTO ZazzleOrder (OrderId,OrderDate,ShipDate,DeliveryMethod,Priority
                                     ,Currency,IsReprint,ReprintReason,ReprintOriginalId,ShipAddr1,ShipAddr2,ShipAddr3
                                     ,Name,Name2,City,State,Country,Zip,Phone,Email,ShipType,PkPageNumber,PkPageType,PkPageDescription,PkUrl) Values(@OrderId
                                     ,@OrderDate,@ShipDate,@DeliveryMethod,@Priority,@Currency,@IsReprint,@ReprintReason
                                     ,@ReprintOriginalId,@ShipAddr1,@ShipAddr2,@ShipAddr3,@Name,@Name2,@City,@State,@Country
                                     ,@Zip,@Phone,@Email,@ShipType,@PkPageNumber,@PkPageType,@PkPageDescription,@PkUrl)");
            sqlClientDetail.CommandText(@"Insert INTO ZazzleOrderDetail (Invno,ItemId,OrderId,ItemType,Quantity,Price
                                        ,NumPerPack,Description,Attributes,ReprintInstructions,Products,ProductId) Values(@Invno,@ItemId,@OrderId,@ItemType,@Quantity,@Price
                                        ,@NumPerPack,@Description,@Atrtributes,@ReprintInstructions,@Products,@ProductId)");
            var vOrders = model.Result.Orders.Order;
            foreach (var order in vOrders)
            {

                sqlClient.ClearParameters();
                sqlClient.AddParameter("@OrderId", order.OrderId);
                sqlClient.AddParameter("@OrderDate", order.OrderDate);
                sqlClient.AddParameter("@ShipDate", order.ShipByDate);
                sqlClient.AddParameter("@DeliveryMethod", order.DeliveryMethod);
                sqlClient.AddParameter("@Priority", order.Priority);
                sqlClient.AddParameter("@Currency", order.Currency);
                sqlClient.AddParameter("@IsReprint", order.Reprint.ReprintReason == "" ? false : true);
                sqlClient.AddParameter("@ReprintReason", order.Reprint.ReprintReason);
                sqlClient.AddParameter("@RePrintOriginalId", order.Reprint.OriginalOrderId);
                sqlClient.AddParameter("@ShipAddr1", order.ShippingAddress.Address1);
                sqlClient.AddParameter("@ShipAddr2", order.ShippingAddress.Address2);
                sqlClient.AddParameter("@ShipAddr3", order.ShippingAddress.Address3);
                sqlClient.AddParameter("@Name", order.ShippingAddress.Name);
                sqlClient.AddParameter("@Name2", order.ShippingAddress.Name2);
                sqlClient.AddParameter("@City", order.ShippingAddress.City);
                sqlClient.AddParameter("@State", order.ShippingAddress.State);
                sqlClient.AddParameter("@Country", order.ShippingAddress.Country);
                sqlClient.AddParameter("@Zip", order.ShippingAddress.Zip);
                sqlClient.AddParameter("@Phone", order.ShippingAddress.Phone);
                sqlClient.AddParameter("@Email", order.ShippingAddress.Email);
                sqlClient.AddParameter("@ShipType", order.ShippingAddress.Type);
                sqlClient.AddParameter("@PkPageNumber", order.PackingSheet.Page.PageNumber);
                sqlClient.AddParameter("@PkPageType", order.PackingSheet.Page.Front.Type);
                sqlClient.AddParameter("@PkPageDescription", order.PackingSheet.Page.Front.Description);
                sqlClient.AddParameter("@PkPageUrl", order.PackingSheet.Page.Front.Url);
                var insertResult = sqlClient.Insert();
                if (insertResult.IsError)
                {
                    log.Error("Failed to Insert Order(" + order.OrderId.ToString() + "):" + insertResult.Errors[0].DeveloperMessage);
                    new EmailHelper().SendEmail("Failed to Insert Order(" + order.OrderId.ToString() + ")", ApplicationConfig.ErrorEmailAddress, "", "Failed to Insert Order(" + order.OrderId.ToString() + "):" + insertResult.Errors[0].DeveloperMessage);
                    continue;
                }
          
                foreach (var item in order.LineItems.LineItem)
                {
                    sqlClientDetail.ClearParameters();
                    sqlClientDetail.AddParameter("@ItemId", item.LineItemId);
                    sqlClientDetail.AddParameter("@OrderId", order.OrderId);
                    sqlClientDetail.AddParameter("@ItemType", item.LineItemType);
                    sqlClientDetail.AddParameter("@Quantity", item.Quantity);
                    sqlClientDetail.AddParameter("@NumPerPack", item.NumPerPack);
                    sqlClientDetail.AddParameter("@Description", item.Description);
                    sqlClientDetail.AddParameter("@Attributes", item.Attributes);
                    sqlClientDetail.AddParameter("@ReprintInstructions", item.ReprintInstructions);
                    sqlClientDetail.AddParameter("@Price", item.Price);
                    sqlClientDetail.AddParameter("@ProductId", item.ProductId);
                    var detailResult = sqlClientDetail.Insert();
                    if (detailResult.IsError)
                    {
                        log.Error("Failed to Insert Order Detail(" + order.OrderId.ToString() + "| ItemId:" + item.LineItemId + "):" + detailResult.Errors[0].DeveloperMessage);
                        new EmailHelper().SendEmail("Failed to Insert Order Detail(" + order.OrderId.ToString() + "|| ItemId:" + item.LineItemId + ")", ApplicationConfig.ErrorEmailAddress, "", "Failed to Insert Order Detail(" + order.OrderId.ToString() + "):" + insertResult.Errors[0].DeveloperMessage);
                        continue;
                    }
                    sqlClientFile.CommandText(@"Insert INTO ZazzleItemFiles (ItemId,FileType,Type,Description,Url)                                  ,PreviewDescription,TextFileUrl,PackingSheet,PSPageNumber,PSType,PSUrl) 
                                        Values(@ItemId,@FileType,@Type,@Description,@Url) ");
                    var vInvno = detailResult.Data;
                    foreach (var file in item.PrintFiles)
                    {
                        sqlClientFile.ClearParameters();
                        sqlClientFile.AddParameter("@Invno", vInvno);
                        sqlClientFile.AddParameter("@ItemId", detailResult.Data);
                        sqlClientFile.AddParameter("@FileType", "PRINT");
                        sqlClientFile.AddParameter("@Type", file.Type);
                        sqlClientFile.AddParameter("@PrintDescription", file.Description);
                        sqlClientFile.AddParameter("@PrintUrl", file.Url);
                        var fileInsertResult=sqlClientFile.Insert();
                        if (fileInsertResult.IsError)
                        {
                            string jsonstr = JsonSerializer.Serialize(file);
                            this.log.Error("Error inserting Pint Files Record:" + fileInsertResult.Errors[0].DeveloperMessage + " || " + jsonstr);
                            new EmailHelper().SendEmail("Error inserting Pint Files Record", ApplicationConfig.ErrorEmailAddress, "", "Error inserting Pint Files Record:" + fileInsertResult.Errors[0].DeveloperMessage + " || " + jsonstr);
                        }

                    } //file foreach1
                    foreach (var file in item.Previews)
                    {
                        sqlClientFile.ClearParameters();
                        sqlClientFile.AddParameter("@Invno", vInvno);
                        sqlClientFile.AddParameter("@ItemId", detailResult.Data);
                        sqlClientFile.AddParameter("@FileType", "PREVIEW");
                        sqlClientFile.AddParameter("@Type", file.Type);
                        sqlClientFile.AddParameter("@PrintDescription", file.Description);
                        sqlClientFile.AddParameter("@PrintUrl", file.Url);
                        var fileInsertResult1= sqlClientFile.Insert();
                        if (fileInsertResult1.IsError) {
                            string jsonstr = JsonSerializer.Serialize(file);
                            this.log.Error("Error inserting Preview Files Record:" + fileInsertResult1.Errors[0].DeveloperMessage + " || " + jsonstr);
                            new EmailHelper().SendEmail("Error inserting Preview Files Record", ApplicationConfig.ErrorEmailAddress, "", "Error inserting Pint Files Record:" + fileInsertResult1.Errors[0].DeveloperMessage + " || " + jsonstr);
                        }

                    } //file foreach2
                    //packing list files
                   
                    sqlClientFile.ClearParameters();
                    sqlClientFile.AddParameter("@Invno", vInvno);
                    sqlClientFile.AddParameter("@ItemId", order.OrderId);
                    sqlClientFile.AddParameter("@FileType", "PACKINGSHEET");
                    sqlClientFile.AddParameter("@Type", order.PackingSheet.Page.Front.Type);
                    sqlClientFile.AddParameter("@PrintDescription", order.PackingSheet.Page.Front.Description);
                    sqlClientFile.AddParameter("@PrintUrl", order.PackingSheet.Page.Front.Url);
                    var fileInsertResult2  =sqlClientFile.Insert();
                    if (fileInsertResult2.IsError) {
                        string jsonstr = JsonSerializer.Serialize(order.PackingSheet);
                        this.log.Error("Error inserting PackingList Files Record:" + fileInsertResult2.Errors[0].DeveloperMessage + " || " + jsonstr);
                        new EmailHelper().SendEmail("Error inserting PackingList Files Record", ApplicationConfig.ErrorEmailAddress, "", "Error inserting PackingList Files Record:" + fileInsertResult2.Errors[0].DeveloperMessage + " || " + jsonstr);
                    }
                    //Insert Production Rec
                    var prodSqlClient = new SQLCustomClient();
                    prodSqlClient.CommandText(@"INSERT INTO Produtn (Invno,Company,Schcode,Prodno,KitRecvd,NoCopies,Screcv,PrshpDte,ZazzleOrderId) Values(@Invno,@Company,@Schcode,@Prodno,GETDATE(),@NoCopies,GETDATE(),@PrshpDte,@ZazzleOrderId)");
                    prodSqlClient.AddParameter("@Invno",vInvno);
                    prodSqlClient.AddParameter("@Company","ZAZ");
                    prodSqlClient.AddParameter("@Schcode","02");
                    prodSqlClient.AddParameter("@Prodno",vInvno);
                    prodSqlClient.AddParameter("@NoCopies", item.Quantity);
                    prodSqlClient.AddParameter("@PrshpDte", order.ShipByDate);
                    prodSqlClient.AddParameter("@PrshpDte", order.ShipByDate);
                    prodSqlClient.AddParameter("@ZazzleOrderId",order.OrderId);
                    var prodResult = prodSqlClient.Insert();
                    if (prodResult.IsError)
                    {
                        log.Error("Failed to insert prod record(" + vInvno.ToString() + ":" + prodResult.Errors[0].DeveloperMessage);
                        new EmailHelper().SendEmail("Failed to insert prod record(" + vInvno.ToString(),ApplicationConfig.ErrorEmailAddress,"", "Failed to insert prod record(" + vInvno.ToString() + ":" + prodResult.Errors[0].DeveloperMessage);
                    }

                    //Insert WIP Rec
                    var wipSqlClient = new SQLCustomClient();
                    wipSqlClient.CommandText(@" Insert Into Wip (Invno,Schcode)Values(@Invno,'01'))");
                    wipSqlClient.AddParameter("@Invno", vInvno);
                    wipSqlClient.AddParameter("@Schcode", "02");
                    var wipResult = wipSqlClient.Insert();
                    if (prodResult.IsError)
                    {
                        log.Error("Failed to insert wip record(" + vInvno.ToString() + ":" + prodResult.Errors[0].DeveloperMessage);
                        new EmailHelper().SendEmail("Failed to insert wip record(" + vInvno.ToString(), ApplicationConfig.ErrorEmailAddress, "", "Failed to insert wip record(" + vInvno.ToString() + ":" + prodResult.Errors[0].DeveloperMessage);
                    }

                }//end orderdetail     
            }//order foreach
            //BackgroundJob.Enqueue(() => FinalizeOrderReceived(InvnoJobs, false));//download files
            return processingResult;
        }
        private async Task<ApiProcessingResult<int>> GetInvno()
        {
            var processingResult = new ApiProcessingResult<int>() { Data = 0 };
            var result = new SQLCustomClient().CommandText("Select MAX(Invno) as Invno from ZazzleOrderDetail").SelectSingleColumn();
            if (result.IsError)
            {
                this.log.Error("Failed to get Invno:" + result.Errors[0].DeveloperMessage);
                processingResult.IsError = true;
                return processingResult;
            }

            var strInvno = result.Data;
            int iInvno = int.Parse(strInvno);
            processingResult.Data = iInvno + 1;

            return processingResult;
        }

    }
}
