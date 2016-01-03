using VV.Web.Core.Models;
using Nancy;
using Nancy.Owin;
using Nancy.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using Nancy.ViewEngines.Razor;

namespace VV.Web.Core.Modules
{
     public class RootModule : NancyModule
     {
          public RootModule()
          {
               //   This will run as Synchronize but we can see the flags for async methodologies.
               Get["/nan/"] = (parameters) => 
               {
                    var env = this.Context.GetOwinEnvironment();

                    var requestBody = (Stream)env["owin.RequestBody"];
                    var requestHeaders = (IDictionary<string, string[]>)env["owin.RequestHeaders"];
                    var requestMethod = (string)env["owin.RequestMethod"];
                    var requestPath = (string)env["owin.RequestPath"];
                    var requestPathBase = (string)env["owin.RequestPathBase"];
                    var requestProtocol = (string)env["owin.RequestProtocol"];
                    var requestQueryString = (string)env["owin.RequestQueryString"];
                    var requestScheme = (string)env["owin.RequestScheme"];

                    var responseBody = (Stream)env["owin.ResponseBody"];
                    var responseHeaders = (IDictionary<string, string[]>)env["owin.ResponseHeaders"];

                    var owinVersion = (string)env["owin.Version"];
                    var cancellationToken = (CancellationToken)env["owin.CallCancelled"];

                    var uri = (string)env["owin.RequestScheme"] + "://" + requestHeaders["Host"].First() +
                      (string)env["owin.RequestPathBase"] + (string)env["owin.RequestPath"];

                    if (env["owin.RequestQueryString"].ToString() != "")
                         uri += "?" + (string)env["owin.RequestQueryString"];
                    var x = string.Format("{0} {1}", requestMethod, uri);
                    var model = new NancyDemoModel() { Id = "tas", Test = "NOOOOOO" };
                    return View["Index.cshtml", model];
               };

               Post["/", true] = async (parameters, ct) =>
               {
                    string link = await GetData(ct);
                    var model = new NancyDemoModel() { Id = "test", Test = link };
                    return View["Index", model];

               };
          }

          private Task<string> GetData(CancellationToken ct)
          {
               //   Process some steps for the model Note this is all done async so process accordingly



               ct.ThrowIfCancellationRequested();
               return Task.FromResult<string>("hello World");
          }
     }
}