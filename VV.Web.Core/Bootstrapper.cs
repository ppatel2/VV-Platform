using Nancy;
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
     }
}