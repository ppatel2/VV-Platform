using VV.HelperClasses;
using VV.Web.DataAccess;
using VV.Middlewares;
using VV.Proxy;
using VV.Web.Auth;
using VV.Utilities;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http.Validation;
using Swashbuckle.Application;
using Swashbuckle.Swagger;
using VV.Web.Engine.Filters;
using Ninject.Web.WebApi.Filter;

namespace VV.Web.Engine

{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            Logger.Log.Info("Application started!!!");
            ConfigureOAuth(app);

            app.UseRequestLogging();
            //app.Use<ForceHttpsMiddleware>();
            //app.Use<TenantResolver>();
            SelfHostAssemblyResolver assemblyResolver = new SelfHostAssemblyResolver(AppDomain.CurrentDomain.BaseDirectory);

            var configWebApi = new HttpConfiguration();
            configWebApi.MapHttpAttributeRoutes();
            configWebApi.Formatters.Add(new BrowserJsonFormatter());
            configWebApi.Formatters.XmlFormatter.MediaTypeMappings.Add(new QueryStringMapping("xml", "true", "application/xml"));
            configWebApi.Services.Replace(typeof(IAssembliesResolver), assemblyResolver);
            configWebApi.DependencyResolver = new OwinNinjectDependencyResolver(CreateKernel());
            configWebApi.Filters.Add(new ValidateModelAttribute());
            //configWebApi.Filters.Add(new RequireHttpsAttribute());

            ConfigureSwagger(configWebApi);

            app.UseWebApi(configWebApi);

            Core.Startup.Configuration(app);

            //   As there is no more standard OWIN systems in the pipeline, it will automatically switch to the MVC portion of this project.
            //Trace.Listeners.Remove("HostingTraceListener");
            //Trace.Listeners.Remove("HostingTraceSource");
            //Trace.Listeners.Remove("HostingTraceListener");
            //Trace.Listeners.Remove("HostingTraceSource");
        }

        private static void ConfigureSwagger(HttpConfiguration configWebApi)
        {
            configWebApi.EnableSwagger(c => 
            {
                c.SingleApiVersion("v1", "VV Web API");
                c.DocumentFilter<AuthTokenOperation>();
                c.IncludeXmlComments(GetXmlCommentsPath());
                c.OperationFilter<AddAuthorizationDescription>();
            })
            .EnableSwaggerUi(c =>
            {
                c.InjectJavaScript(typeof(Startup).Assembly, "VV.Web.Engine.SwaggerExtensions.customOAuthPasswordGrantFlow.js");
            });
        }

        private static string GetXmlCommentsPath()
        {
            if (!AppDomain.CurrentDomain.BaseDirectory.Contains("IIS"))
                return System.String.Format(@"{0}\VV.Web.Api.XML", AppDomain.CurrentDomain.BaseDirectory);
            else
                return string.Format(@"{0}\bin\VV.Web.Api.XML", AppDomain.CurrentDomain.BaseDirectory);
        }

        private static void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new Microsoft.Owin.PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new AuthorizationServerProvider()
            };

            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            //kernel.Load(Assembly.GetExecutingAssembly());
            //kernel.Load(System.Reflection.Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory + "\\VV.Web.Api.dll"));
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IDataAccess>().To<DataAccess.DataAccess>();
            kernel.Bind<IBioConnectAPIProxy>().To<BioConnectAPIProxy>();
            
        }
    }
}
