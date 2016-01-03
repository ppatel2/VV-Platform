using VV.Utilities;
using Microsoft.Owin;
using VV.DataObjects;
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
     public class TenantResolver
     {
          AppFunc _next;

          public TenantResolver(AppFunc next)
          {
               _next = next;
          }


          public async Task Invoke(IDictionary<string, object> env)
          {
               var ctx = new OwinContext(env);
               var subDomain = ResolveTenant(ctx);

               if (string.IsNullOrEmpty(subDomain))
               {
                    ctx.Response.StatusCode = 404;
                    return;
               }
     
               ctx.Environment["Tenant"] = new TenantDataObject()
               {
                    Id = -1,
                    SubDomain = subDomain
               };

               await _next(env);
          }

          private string ResolveTenant(OwinContext ctx)
          {
               try
               {

                    var subD = ctx.Request.Uri.Host.Substring(0, ctx.Request.Uri.Host.IndexOf(".")).ToString();
                    return subD;
               }
               catch (Exception ex)
               {
                    return null;
               }


          }
     }
}