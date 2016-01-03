using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using VV.DataObjects;
using VV.Web.DataAccess;
using VV.Proxy;

namespace VV.Web.Api
{
    [RoutePrefix("api")]
    public class BioConnectMainApiController : BaseApiController
    {
        public BioConnectMainApiController(IDataAccess dataAccess, IBioConnectAPIProxy proxy) : base(dataAccess, proxy)
        {

        }

        [Route("v1/status")]
        [HttpGet]
        public IHttpActionResult ApiStatus()
        {
            return Content(System.Net.HttpStatusCode.OK, new StatusJSONObj() { status = "Ok", error = "NOOOOO!!!!!!" });
        }
    }
}