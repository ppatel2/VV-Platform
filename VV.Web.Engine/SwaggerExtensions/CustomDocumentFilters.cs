using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Description;
using Swashbuckle.Application;
using Swashbuckle.SwaggerUi;
using System.Web.Http;

namespace VV.Web.Engine
{
    public class AuthTokenOperation : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            swaggerDoc.paths.Add("/token", new PathItem
            {
                post = new Operation
                {
                    tags = new List<string> { "Auth" },
                    consumes = new List<string>
                {
                    "application/x-www-form-urlencoded"
                },
                    parameters = new List<Parameter> {
                    new Parameter
                    {
                        type = "string",
                        name = "grant_type",
                        required = true,
                        @in = "formData"
                    },
                    new Parameter
                    {
                        type = "string",
                        name = "username",
                        required = true,
                        @in = "formData"
                    },
                    new Parameter
                    {
                        type = "string",
                        name = "password",
                        required = true,
                        @in = "formData"
                    }
                }
                }
            });
        }
    }



    //public class CustomDocumentFilter : IDocumentFilter
    //{
    //    public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
    //    {
    //        foreach(ApiDescription a in apiExplorer.ApiDescriptions)
    //        {
    //            var hahaha = a.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>();
    //            var hahahaha = a.ActionDescriptor.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>();
    //            var y = a.ActionDescriptor.GetFilterPipeline();
                
    //            if(a.ActionDescriptor.GetFilterPipeline().Where(f => f.Instance is AuthorizeAttribute).Any())
    //            {
    //                string x = "haha";
    //                x = "test";
    //            }
    //        }
    //    }
    //}
}
