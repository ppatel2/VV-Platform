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
    public class AddAuthorizationDescription : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (apiDescription.ActionDescriptor.GetFilterPipeline().Where(f => f.Instance is AuthorizeAttribute).Any())
            {
                var authorizeFilters = apiDescription.ActionDescriptor.GetFilterPipeline()
                    .Select(f => f.Instance).OfType<AuthorizeAttribute>()
                    .SelectMany(attr => attr.Roles.Split(',')).Distinct();

                operation.description = String.Format("Authorization required, Roles: {0}",
                    (authorizeFilters.Where(x => x == "Admin").Any()) ? "Admin" : "User");
            }
        }
    }
}
