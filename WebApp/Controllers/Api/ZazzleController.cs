using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core;
namespace src.Controllers.WebApi
{
 
    [Route("api/order")]
    [ApiController]
    public class ZazzleController : ControllerBase
    {
        [HttpGet, Route("ListNewOrders")]
        public async Task<ActionResult> ListNewOrders()
        {
            var processingResult = new ApiProcessingResult();
            return Ok("Home");

        }
    }
}
