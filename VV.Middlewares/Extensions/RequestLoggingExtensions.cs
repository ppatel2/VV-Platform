using VV.Middlewares;
using VV.Middlewares.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Owin
{
     public static class RequestLoggingExtensions
     {
          public static void UseRequestLogging(this IAppBuilder app, RequestLoggingOptions options = null)
          {
               if (options == null)
                    options = new RequestLoggingOptions();

               app.Use<RequestLogging>(options);
          }
     }
}