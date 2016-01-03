using VV.Utilities;
using Microsoft.Owin;
using VV.Middlewares.Options;
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
     public class RequestLogging
     {
          AppFunc _next;
          RequestLoggingOptions _options;

          public RequestLogging(AppFunc next, RequestLoggingOptions options)
          {
               _next = next;
               _options = options;

               Initialize();
          }

          private void Initialize()
          {
               if (_options != null && _options.OnIncomingRequest == null)
                    _options.OnIncomingRequest = (ctx) =>
                    {
                         Logger.Log.DebugFormat("Request from: {0} - Method: {1}", ctx.Request.RemoteIpAddress, ctx.Request.Path);
                         var watch = new System.Diagnostics.Stopwatch();
                         watch.Start();
                         ctx.Environment["DebugStopWatch"] = watch;
                    };

               if (_options != null && _options.OnOutgoingRequest == null)
                    _options.OnOutgoingRequest = (ctx) =>
                    {
                         var watch = (System.Diagnostics.Stopwatch)ctx.Environment["DebugStopWatch"];
                         watch.Stop();
                         Logger.Log.DebugFormat("Completed Request: {0}, Status: {1}, Took: {2}", ctx.Request.Path, ctx.Response.StatusCode, 
                              watch.ElapsedMilliseconds + " ms");
                    };
          }

          public async Task Invoke(IDictionary<string,object> env)
          {
               var ctx = new OwinContext(env);

               _options.OnIncomingRequest(ctx);
              await _next(env);
               _options.OnOutgoingRequest(ctx);
          }    

     }
}