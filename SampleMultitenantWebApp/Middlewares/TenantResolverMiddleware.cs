using Entertech.Utilities;
using Microsoft.Owin;
using SampleMultitenantWebApp.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AppFunc = System.Func<
     System.Collections.Generic.IDictionary<string, object>,
     System.Threading.Tasks.Task
     >;

namespace SampleMultitenantWebApp.Middlewares
{
     public class TenantResolverMiddleware
     {
          private readonly int port;
          private readonly AppFunc _next;

          public TenantResolverMiddleware(AppFunc next)
          {
               this._next = next;
          }

          public async Task Invoke(IDictionary<string, object> env)
          {
               var ctx = new OwinContext(env);
               if (ctx.Request.Uri != null)
               {
                    Logger.Log.DebugFormat("Rerouting to HTTPS: {0}", ctx.Request.Uri.AbsoluteUri);
                    var tenant = da.GetTenant(DetermineTenant(ctx));
                    

                    Logger.Log.DebugFormat("Resolved tenant. Current tenant: {0}", tenant.Id);

                    
                    await _next(env);
               }
          }

          private string DetermineTenant(OwinContext ctx)
          {

               ctx.Request.



          }


     }
}