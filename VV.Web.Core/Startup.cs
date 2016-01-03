using VV.Middlewares;
using VV.Utilities;
using Nancy;
using Nancy.Owin;
using Owin;
using System.Diagnostics;

namespace VV.Web.Core
{
     public class Startup
     {

          public static void Configuration(IAppBuilder app)
          {
               //Logger.Log.Info("Application started!!!");
               //app.UseRequestLogging();
               //app.Use<ForceHttpsMiddleware>();
               ////app.Use<TenantResolver>();


              

               app.UseNancy(options => options.PassThroughWhenStatusCodesAre(HttpStatusCode.NotFound,
                   HttpStatusCode.InternalServerError));


               //   As there is no more standard OWIN systems in the pipeline, it will automatically switch to the MVC portion of this project.
               //Trace.Listeners.Remove("HostingTraceListener");
               //Trace.Listeners.Remove("HostingTraceSource");
          }

     }
}