using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Routing;

namespace VV.Web.Api
{
    public class ForbiddenActionResult : IHttpActionResult
    {
        HttpResponseMessage response;

        public ForbiddenActionResult(HttpResponseMessage response)
        {
            this.response = response;
            this.response.StatusCode = HttpStatusCode.Forbidden;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(ExecuteResult());
        }

        public HttpResponseMessage ExecuteResult()
        {
            return response;
        }
    }
}
