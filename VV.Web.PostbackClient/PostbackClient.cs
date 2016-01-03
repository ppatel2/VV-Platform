using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using VV.Web.Models;

namespace VV.Web.PostbackClient
{
    public class PostbackClient
    {
        public static async Task EnrollPostback(string postbackUrl, UsersEnrollPostbackModel postbackModel)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.PostAsJsonAsync(postbackUrl, postbackModel).Result;
            }
        }
    }
}
