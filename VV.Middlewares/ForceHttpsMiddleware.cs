using VV.Utilities;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AppFunc = System.Func<
     System.Collections.Generic.IDictionary<string, object>,
     System.Threading.Tasks.Task
     >;

namespace VV.Middlewares
{
     public class ForceHttpsMiddleware
     {
          private readonly int port;
          private readonly AppFunc _next;

          public ForceHttpsMiddleware(AppFunc next)
          {
               this._next = next;
               this.port = 443;
          }


          public ForceHttpsMiddleware(AppFunc next, int port) 
          {
               this._next = next;
               this.port = port;
          }

          public async Task Invoke(IDictionary<string, object> env)
          {
               var ctx = new OwinContext(env);
               if (ctx.Request.Uri != null)
               {
                    Logger.Log.DebugFormat("Rerouting to HTTPS: {0}", ctx.Request.Uri.AbsoluteUri);
                    if (ctx.Request.Uri.Scheme == "http")
                    {
                         var httpsUrl = string.Format("https://{0}:{1}{2}", ctx.Request.Uri.Host,
                             port,
                             ctx.Request.Uri.PathAndQuery);

                         ctx.Response.Redirect(httpsUrl);
                    }
                    await _next(env);
               }
               else
               {
                    Logger.Log.ErrorFormat("Request came in Null!!! {0}", ctx.Request.RemoteIpAddress);
                    await ctx.Response.WriteAsync("Hello World!!!!");
               }
          }
     }
}