using System;
using System.Collections.Generic;
using System.Text;
Address1
namespace ApiBindingModels
{


    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Response
    {

        private ResponseStatus statusField;

        private ResponseResult resultField;

        /// <remarks/>
        public ResponseStatus Status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <remarks/>
        public ResponseResult Result
        {
            get
            {
                return this.resultField;
            }
            set
            {
                this.resultField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ResponseStatus
    {

        private string codeField;

        private object infoField;

        /// <remarks/>
        public string Code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
            }
        }

        /// <remarks/>
        public object Info
        {
            get
            {
                return this.infoField;
            }
            set
            {
                this.infoField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ResponseResult
    {

        private ResponseResultOrders ordersField;

        private ResponseResultShippingInfo shippingInfoField;

        /// <remarks/>
        public ResponseResultOrders Orders
        {
            get
            {
                return this.ordersField;
            }
            set
            {
                this.ordersField = value;
            }
        }

        /// <remarks/>
        public ResponseResultShippingInfo ShippingInfo
        {
            get
            {
                return this.shippingInfoField;
            }
            set
            {
                this.shippingInfoField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ResponseResultOrders
    {

        private List<ResponseResultOrdersOrder> orderField;

        /// <remarks/>
        public List<ResponseResultOrdersOrder> Order
        {
            get
            {
                return this.orderField;
            }
            set
            {
                this.orderField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ResponseResultOrdersOrder
    {

        private ResponseResultOrdersOrderUpdate updateField;

        private ulong orderIdField;

        private string orderDateField;

        private string shipByDateField;

        private string orderTypeField;

        private string deliveryMethodField;

        private string priorityField;

        private string currencyField;

        private string statusField;

        private string attributesField;

        private ResponseResultOrdersOrderReprint reprintField;

        private ResponseResultOrdersOrderShippingAddress shippingAddressField;

        private ResponseResultOrdersOrderLineItems lineItemsField;

        private ResponseResultOrdersOrderProducts productsField;

        private ResponseResultOrdersOrderPackingSheet packingSheetField;

        private object messagesField;

        /// <remarks/>
        public ResponseResultOrdersOrderUpdate Update
        {
            get
            {
                return this.updateField;
            }
            set
            {
                this.updateField = value;
            }
        }

        /// <remarks/>
        public ulong OrderId
        {
            get
            {
                return this.orderIdField;
            }
            set
            {
                this.orderIdField = value;
            }
        }

        /// <remarks/>
        public string OrderDate
        {
            get
            {
                return this.orderDateField;
            }
            set
            {
                this.orderDateField = value;
            }
        }

        /// <remarks/>
        public string ShipByDate
        {
            get
            {
                return this.shipByDateField;
            }
            set
            {
                this.shipByDateField = value;
            }
        }

        /// <remarks/>
        public string OrderType
        {
            get
            {
                return this.orderTypeField;
            }
            set
            {
                this.orderTypeField = value;
            }
        }

        /// <remarks/>
        public string DeliveryMethod
        {
            get
            {
                return this.deliveryMethodField;
            }
            set
            {
                this.deliveryMethodField = value;
            }
        }

        /// <remarks/>
        public string Priority
        {
            get
            {
                return this.priorityField;
            }
            set
            {
                this.priorityField = value;
            }
        }

        /// <remarks/>
        public string Currency
        {
            get
            {
                return this.currencyField;
            }
            set
            {
                this.currencyField = value;
            }
        }

        /// <remarks/>
        public string Status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <remarks/>
        public string Attributes
        {
            get
            {
                return this.attributesField;
            }
            set
            {
                this.attributesField = value;
            }
        }

        /// <remarks/>
        public ResponseResultOrdersOrderReprint Reprint
        {
            get
            {
                return this.reprintField;
            }
            set
            {
                this.reprintField = value;
            }
        }

        /// <remarks/>
        public ResponseResultOrdersOrderShippingAddress ShippingAddress
        {
            get
            {
                return this.shippingAddressField;
            }
            set
            {
                this.shippingAddressField = value;
            }
        }

        /// <remarks/>
        public ResponseResultOrdersOrderLineItems LineItems
        {
            get
            {
                return this.lineItemsField;
            }
            set
            {
                this.lineItemsField = value;
            }
        }

        /// <remarks/>
        public ResponseResultOrdersOrderProducts Products
        {
            get
            {
                return this.productsField;
            }
            set
            {
                this.productsField = value;
            }
        }

        /// <remarks/>
        public ResponseResultOrdersOrderPackingSheet PackingSheet
        {
            get
            {
                return this.packingSheetField;
            }
            set
            {
                this.packingSheetField = value;
            }
        }

        /// <remarks/>
        public object Messages
        {
            get
            {
                return this.messagesField;
            }
            set
            {
                this.messagesField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ResponseResultOrdersOrderUpdate
    {

        private object updateTypeField;

        private object updateDateField;

        /// <remarks/>
        public object UpdateType
        {
            get
            {
                return this.updateTypeField;
            }
            set
            {
                this.updateTypeField = value;
            }
        }

        /// <remarks/>
        public object UpdateDate
        {
            get
            {
                return this.updateDateField;
            }
            set
            {
                this.updateDateField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ResponseResultOrdersOrderReprint
    {

        private string reprintReasonField;

        private ulong originalOrderIdField;

        /// <remarks/>
        public string ReprintReason
        {
            get
            {
                return this.reprintReasonField;
            }
            set
            {
                this.reprintReasonField = value;
            }
        }

        /// <remarks/>
        public ulong OriginalOrderId
        {
            get
            {
                return this.originalOrderIdField;
            }
            set
            {
                this.originalOrderIdField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ResponseResultOrdersOrderShippingAddress
    {

        private string address1Field;

        private string address2Field;

        private object address3Field;

        private string nameField;

        private object name2Field;

        private string cityField;

        private string stateField;

        private string countryField;

        private string countryCodeField;

        private uint zipField;

        private string phoneField;

        private string emailField;

        private string typeField;

        /// <remarks/>
        public string Address1
        {
            get
            {
                return this.address1Field;
            }
            set
            {
                this.address1Field = value;
            }
        }

        /// <remarks/>
        public string Address2
        {
            get
            {
                return this.address2Field;
            }
            set
            {
                this.address2Field = value;
            }
        }

        /// <remarks/>
        public object Address3
        {
            get
            {
                return this.address3Field;
            }
            set
            {
                this.address3Field = value;
            }
        }

        /// <remarks/>
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public object Name2
        {
            get
            {
                return this.name2Field;
            }
            set
            {
                this.name2Field = value;
            }
        }

        /// <remarks/>
        public string City
        {
            get
            {
                return this.cityField;
            }
            set
            {
                this.cityField = value;
            }
        }

        /// <remarks/>
        public string State
        {
            get
            {
                return this.stateField;
            }
            set
            {
                this.stateField = value;
            }
        }

        /// <remarks/>
        public string Country
        {
            get
            {
                return this.countryField;
            }
            set
            {
                this.countryField = value;
            }
        }

        /// <remarks/>
        public string CountryCode
        {
            get
            {
                return this.countryCodeField;
            }
            set
            {
                this.countryCodeField = value;
            }
        }

        /// <remarks/>
        public uint Zip
        {
            get
            {
                return this.zipField;
            }
            set
            {
                this.zipField = value;
            }
        }

        /// <remarks/>
        public string Phone
        {
            get
            {
                return this.phoneField;
            }
            set
            {
                this.phoneField = value;
            }
        }

        /// <remarks/>
        public string Email
        {
            get
            {
                return this.emailField;
            }
            set
            {
                this.emailField = value;
            }
        }

        /// <remarks/>
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ResponseResultOrdersOrderLineItems
    {

        private List<ResponseResultOrdersOrderLineItemsLineItem> lineItemField;

        /// <remarks/>
        public List<ResponseResultOrdersOrderLineItemsLineItem> LineItem
        {
            get
            {
                return this.lineItemField;
            }
            set
            {
                this.lineItemField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ResponseResultOrdersOrderLineItemsLineItem
    {

        private ulong lineItemIdField;

        private ulong orderIdField;

        private string lineItemTypeField;

        private byte quantityField;

        private byte numPerPackField;

        private string descriptionField;

        private string attributesField;

        private string reprintInstructionsField;

        private string vendorAttributesField;

        private ushort priceField;

        private ulong productIdField;

        private ResponseResultOrdersOrderLineItemsLineItemPrintFile[] printFilesField;

        private ResponseResultOrdersOrderLineItemsLineItemPreviewFile[] previewsField;

        private ResponseResultOrdersOrderLineItemsLineItemSimpleTextFile simpleTextFileField;

        /// <remarks/>
        public ulong LineItemId
        {
            get
            {
                return this.lineItemIdField;
            }
            set
            {
                this.lineItemIdField = value;
            }
        }

        /// <remarks/>
        public ulong OrderId
        {
            get
            {
                return this.orderIdField;
            }
            set
            {
                this.orderIdField = value;
            }
        }

        /// <remarks/>
        public string LineItemType
        {
            get
            {
                return this.lineItemTypeField;
            }
            set
            {
                this.lineItemTypeField = value;
            }
        }

        /// <remarks/>
        public byte Quantity
        {
            get
            {
                return this.quantityField;
            }
            set
            {
                this.quantityField = value;
            }
        }

        /// <remarks/>
        public byte NumPerPack
        {
            get
            {
                return this.numPerPackField;
            }
            set
            {
                this.numPerPackField = value;
            }
        }

        /// <remarks/>
        public string Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        public string Attributes
        {
            get
            {
                return this.attributesField;
            }
            set
            {
                this.attributesField = value;
            }
        }

        /// <remarks/>
        public string ReprintInstructions
        {
            get
            {
                return this.reprintInstructionsField;
            }
            set
            {
                this.reprintInstructionsField = value;
            }
        }

        /// <remarks/>
        public string VendorAttributes
        {
            get
            {
                return this.vendorAttributesField;
            }
            set
            {
                this.vendorAttributesField = value;
            }
        }

        /// <remarks/>
        public ushort Price
        {
            get
            {
                return this.priceField;
            }
            set
            {
                this.priceField = value;
            }
        }

        /// <remarks/>
        public ulong ProductId
        {
            get
            {
                return this.productIdField;
            }
            set
            {
                this.productIdField = value;
            }
        }

    

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("PrintFile", IsNullable = false)]
        public ResponseResultOrdersOrderLineItemsLineItemPrintFile[] PrintFiles
        {
            get
            {
                return this.printFilesField;
            }
            set
            {
                this.printFilesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("PreviewFile", IsNullable = false)]
        public ResponseResultOrdersOrderLineItemsLineItemPreviewFile[] Previews
        {
            get
            {
                return this.previewsField;
            }
            set
            {
                this.previewsField = value;
            }
        }

        /// <remarks/>
        public ResponseResultOrdersOrderLineItemsLineItemSimpleTextFile SimpleTextFile
        {
            get
            {
                return this.simpleTextFileField;
            }
            set
            {
                this.simpleTextFileField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ResponseResultOrdersOrderLineItemsLineItemPrintFile
    {

        private string typeField;

        private string urlField;

        private string descriptionField;

        /// <remarks/>
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        public string Url
        {
            get
            {
                return this.urlField;
            }
            set
            {
                this.urlField = value;
            }
        }

        /// <remarks/>
        public string Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ResponseResultOrdersOrderLineItemsLineItemPreviewFile
    {

        private string typeField;

        private string urlField;

        private string descriptionField;

        /// <remarks/>
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        public string Url
        {
            get
            {
                return this.urlField;
            }
            set
            {
                this.urlField = value;
            }
        }

        /// <remarks/>
        public string Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ResponseResultOrdersOrderLineItemsLineItemSimpleTextFile
    {

        private string urlField;

        /// <remarks/>
        public string Url
        {
            get
            {
                return this.urlField;
            }
            set
            {
                this.urlField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ResponseResultOrdersOrderProducts
    {

        private ResponseResultOrdersOrderProductsProduct productField;

        /// <remarks/>
        public ResponseResultOrdersOrderProductsProduct Product
        {
            get
            {
                return this.productField;
            }
            set
            {
                this.productField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ResponseResultOrdersOrderProductsProduct
    {

        private ulong productldField;

        private object productlnfoField;

        /// <remarks/>
        public ulong Productld
        {
            get
            {
                return this.productldField;
            }
            set
            {
                this.productldField = value;
            }
        }

        /// <remarks/>
        public object Productlnfo
        {
            get
            {
                return this.productlnfoField;
            }
            set
            {
                this.productlnfoField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ResponseResultOrdersOrderPackingSheet
    {

        private ResponseResultOrdersOrderPackingSheetPage pageField;

        /// <remarks/>
        public ResponseResultOrdersOrderPackingSheetPage Page
        {
            get
            {
                return this.pageField;
            }
            set
            {
                this.pageField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ResponseResultOrdersOrderPackingSheetPage
    {

        private string pageNumberField;

        private ResponseResultOrdersOrderPackingSheetPageFront frontField;

        /// <remarks/>
        public string PageNumber
        {
            get
            {
                return this.pageNumberField;
            }
            set
            {
                this.pageNumberField = value;
            }
        }

        /// <remarks/>
        public ResponseResultOrdersOrderPackingSheetPageFront Front
        {
            get
            {
                return this.frontField;
            }
            set
            {
                this.frontField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ResponseResultOrdersOrderPackingSheetPageFront
    {

        private string typeField;

        private string descriptionField;

        private string urlField;

        /// <remarks/>
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        public string Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        public string Url
        {
            get
            {
                return this.urlField;
            }
            set
            {
                this.urlField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ResponseResultShippingInfo
    {

        private string carrierField;

        private string methodField;

        private string trackingNumberField;

        private byte weightField;

        private ResponseResultShippingInfoShippingDocument[] shippingDocumentsField;

        /// <remarks/>
        public string Carrier
        {
            get
            {
                return this.carrierField;
            }
            set
            {
                this.carrierField = value;
            }
        }

        /// <remarks/>
        public string Method
        {
            get
            {
                return this.methodField;
            }
            set
            {
                this.methodField = value;
            }
        }

        /// <remarks/>
        public string TrackingNumber
        {
            get
            {
                return this.trackingNumberField;
            }
            set
            {
                this.trackingNumberField = value;
            }
        }

        /// <remarks/>
        public byte Weight
        {
            get
            {
                return this.weightField;
            }
            set
            {
                this.weightField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ShippingDocument", IsNullable = false)]
        public ResponseResultShippingInfoShippingDocument[] ShippingDocuments
        {
            get
            {
                return this.shippingDocumentsField;
            }
            set
            {
                this.shippingDocumentsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ResponseResultShippingInfoShippingDocument
    {

        private string typeField;

        private object formatField;

        private object urlField;

        /// <remarks/>
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        public object Format
        {
            get
            {
                return this.formatField;
            }
            set
            {
                this.formatField = value;
            }
        }

        /// <remarks/>
        public object Url
        {
            get
            {
                return this.urlField;
            }
            set
            {
                this.urlField = value;
            }
        }
    }


}
