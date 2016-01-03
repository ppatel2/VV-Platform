using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Extensions;

[assembly: OwinStartup(typeof(VV.Web.IIS.Startup))]

namespace VV.Web.IIS
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            Engine.Startup.Configuration(app);

            app.UseStageMarker(PipelineStage.MapHandler);

        }
    }
}
