using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Net.Http;
using System.Web.Http.Controllers;
using VV.DataObjects;
using VV.Web.DataAccess;
using VV.Web.Models;
using VV.Proxy;
using VV.Web.Server;
using VV.Web.Server.DataModels;
using VV.Web.Server.HelperClasses;

namespace VV.Web.Api
{
    [RoutePrefix("api/v1/enrollback")]
    public class TestEnrollPostbackController : BaseApiController
    {
        EnrollmentServer enrollmentServer;
        public TestEnrollPostbackController(IDataAccess dataAccess, IBioConnectAPIProxy proxy) : base(dataAccess, proxy)
        {
            enrollmentServer = new EnrollmentServer(proxy);
        }

        /// <summary>
        /// Used as testing callback url for UsersApi enroll
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("")]
        [HttpPost]
        public IHttpActionResult Post([FromBody] UsersEnrollPostbackModel model)
        {
            if (model.ReturnCode == 200)
            {
                string base64 = model.Base64PNGImage;

                //BitmapImageConverter.saveBitmapImage(base64);
                BitmapImageConverter.savePNGImage(base64);
            }

            return Ok();
        }
    }
}
