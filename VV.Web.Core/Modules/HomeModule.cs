using Nancy;
using Nancy.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VV.Utilities;
using VV.Web.Core.Models;

namespace VV.Web.Core.Modules
{
     public class HomeModule : NancyModule
     {
          public HomeModule()
          {
               Get["/Home"] = _ =>
               {
                   try
                   {
                       this.RequiresAuthentication();
                       var model = new NancyDemoModel() { Id = "tas", Test = "NOOOOOO" };

                       return View["Home.cshtml", model];
                   }
                   catch (Exception ex)
                   {
                       Logger.Log.InfoFormat("Authorization: Home: {0}", ex.Message);
                       return Response.AsRedirect("/pages");
                   }
               };
          }
     }
}