using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.Diagnostics;
using Nancy.TinyIoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VV.Web.Core
{
     public class Bootstrapper : DefaultNancyBootstrapper
     {
          protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
          {
               StaticConfiguration.EnableRequestTracing = true;
          }

          protected override void ConfigureConventions(NancyConventions nancyConventions)
          {
               this.Conventions.ViewLocationConventions.Add((viewName, model, context) =>
               {
                    var x = string.Concat("bin/Views/", viewName);
                   var y = context.ModulePath;
                    return x;
               });
               
               nancyConventions.StaticContentsConventions.Add(
                   StaticContentConventionBuilder.AddDirectory("Assets",@"Assets")
               );
               base.ConfigureConventions(nancyConventions);

          }

          protected override DiagnosticsConfiguration DiagnosticsConfiguration
          {
               get { return new DiagnosticsConfiguration { Password = @"a" }; }
          }
        protected override void ConfigureRequestContainer(TinyIoCContainer container, NancyContext context)
        {
            base.ConfigureRequestContainer(container, context);

            // Here we register our user mapper as a per-request singleton.
            // As this is now per-request we could inject a request scoped
            // database "context" or other request scoped services.
            container.Register<IUserMapper, UserDatabase>();
        }

        protected override void RequestStartup(TinyIoCContainer requestContainer, 
            IPipelines pipelines, NancyContext context)
        {
            // At request startup we modify the request pipelines to
            // include forms authentication - passing in our now request
            // scoped user name mapper.
            //
            // The pipelines passed in here are specific to this request,
            // so we can add/remove/update items in them as we please.
            var formsAuthConfiguration =
                new FormsAuthenticationConfiguration()
                {
                    RedirectUrl = "~/pages/login",
                    UserMapper = requestContainer.Resolve<IUserMapper>(),
                };

            FormsAuthentication.Enable(pipelines, formsAuthConfiguration);
        }
        

    }
}