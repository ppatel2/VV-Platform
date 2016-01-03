using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dispatcher;

namespace VV.Web.Engine
{
     public class SelfHostAssemblyResolver : DefaultAssembliesResolver
     {
          string path = string.Empty;
          public SelfHostAssemblyResolver(string path)
          {
               this.path = path;
          }

        public override ICollection<System.Reflection.Assembly> GetAssemblies()
        {
            var baseAssemblies = base.GetAssemblies();
            List<System.Reflection.Assembly> assemblies = new List<System.Reflection.Assembly>(baseAssemblies);

            if (!path.Contains("IIS"))
                assemblies.Add(System.Reflection.Assembly.LoadFile(path + "\\VV.Web.Api.dll"));

            return assemblies;
        }
     }
}
