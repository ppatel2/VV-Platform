using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Entertech.Utilities;
using Owin;
using BioConnect.Middlewares;
using System.Web.Http;
using BioConnect.HelperClasses;
using System.Net.Http.Formatting;

namespace BioConnect
{
     public class Startup
     {


          public static void Configuration(IAppBuilder app)
          {
               Logger.Log.Info("Application started!!!");
               app.UseRequestLogging();
               app.Use<ForceHttpsMiddleware>();
               //app.Use<TenantResolver>();

               app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions {
                    AuthenticationType = "AuthenticationCookie",
                    LoginPath = new Microsoft.Owin.PathString("/Auth/Login")
               });

               var configWebApi = new HttpConfiguration();
               configWebApi.MapHttpAttributeRoutes();
               configWebApi.Formatters.Add(new BrowserJsonFormatter());
               configWebApi.Formatters.XmlFormatter.MediaTypeMappings.Add(new QueryStringMapping("xml", "true", "application/xml"));
               app.UseWebApi(configWebApi);
               
               //   As there is no more standard OWIN systems in the pipeline, it will automatically switch to the MVC portion of this project.
               Trace.Listeners.Remove("HostingTraceListener");
               Trace.Listeners.Remove("HostingTraceSource");
          }

     }
}