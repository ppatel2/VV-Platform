using BioConnect.DataObjects;
using Suprema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BioConnect.Controllers.WebAPI
{
     [RoutePrefix("api")]
     public class BioConnectMainApiController : ApiController
     {
          UFMatcher matcher = new UFMatcher();

          [Route("v1/status")]
          [HttpGet]
          public IHttpActionResult ApiStatus()
          {
               var result = matcher.InitResult;

               return Content(System.Net.HttpStatusCode.OK, new StatusJSONObj() { status = "Ok", error = "NOOOOO!!!!!!" });
          }
          
     }
}