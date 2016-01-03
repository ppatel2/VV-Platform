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
    public class OkActionResultWithPagingHeaders : IHttpActionResult
    {
        HttpResponseMessage response;

        public OkActionResultWithPagingHeaders(string routename, HttpResponseMessage response, int page, int pagesize, int pagecount, int totalcount)
        {
            this.response = response;
            response.StatusCode = HttpStatusCode.OK;

            var requestparams = response.RequestMessage.GetQueryNameValuePairs();
            var parameters = new HttpRouteValueDictionary();
            foreach(KeyValuePair<string,string> kvp in requestparams)
            {
                parameters.Add(kvp.Key, kvp.Value);
            }
            
            var helper = new UrlHelper(response.RequestMessage);

            if (!parameters.Any(x => x.Key == "page"))
            {
                parameters.Add("page", page - 1);
            }
            else parameters["page"] = page - 1;
            var prevUrl = page > 0 ? helper.Link(routename, parameters) : "";

            parameters["page"] = page + 1;
            var nextUrl = page < pagecount - 1 ? helper.Link(routename, parameters) : "";

            response.Headers.Add("X-Paging-PageNo", page.ToString());
            response.Headers.Add("X-Paging-PageSize", pagesize.ToString());
            response.Headers.Add("X-Paging-PageCount", pagecount.ToString());
            response.Headers.Add("X-Paging-TotalRecordCount", totalcount.ToString());
            response.Headers.Add("X-Paging-PrevPage", prevUrl);
            response.Headers.Add("X-Paging-NextPage", nextUrl);
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
