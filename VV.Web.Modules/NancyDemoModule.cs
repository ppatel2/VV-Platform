using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Nancy.Owin;


namespace BioConnect.Web.Modules
{
    public class NancyDemoModule : NancyModule
    {
          public NancyDemoModule()
          {
               Get["/", runAsync:true] = async (x, ct) => 
               {
                    var data = await GetData("Hello World");
                    var model = new { QrPath = data };
                    return View["Index", model];

               };
          }

    }
}
