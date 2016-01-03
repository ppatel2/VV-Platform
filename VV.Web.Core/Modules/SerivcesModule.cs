using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.Owin;
using VV.Web.Core.Models;

namespace VV.Web.Core.Modules
{
     public class SerivcesModule : NancyModule
     {
          public SerivcesModule()
          {
               Get["/services/"] = (parameters) =>
               {
                    var env = this.Context.GetOwinEnvironment();
                    var model = new ServicesDataModel();
                    return View["Services.cshtml", model];
               };

          }
     }
}