using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VV.Middlewares.Options
{
     public class RequestLoggingOptions
     {
          public Action<IOwinContext> OnIncomingRequest { get; set; }
          public Action<IOwinContext> OnOutgoingRequest { get; set; }
     }
}