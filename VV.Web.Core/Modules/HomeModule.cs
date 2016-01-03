using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VV.Web.Core.Models;

namespace VV.Web.Core.Modules
{
     public class HomeModule : NancyModule
     {
          public HomeModule()
          {
               Get["/Home"] = _ =>
               {
                   var model = new NancyDemoModel() { Id = "tas", Test = "NOOOOOO" };

                   return View["Home.cshtml", model];
               };
          }
     }
}