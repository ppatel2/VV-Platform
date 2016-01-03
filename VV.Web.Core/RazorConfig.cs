using Nancy.ViewEngines.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VV.Web.Core
{
     public class RazorConfig : IRazorConfiguration
     {
          public IEnumerable<string> GetAssemblyNames()
          {
               yield return "VV.Web.Core";
          }

          public IEnumerable<string> GetDefaultNamespaces()
          {
               yield return "VV.Web.Core.Modules";
               yield return "VV.Web.Core.Models";
          }

          public bool AutoIncludeModelNamespace
          {
               get { return true; }
          }
     }
}