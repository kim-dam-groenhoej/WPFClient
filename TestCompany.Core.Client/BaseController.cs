using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TestCompany.Core.Client
{
    public class BaseController
    {
        /// <summary>
        /// Use same httpclient instance in hold application to reduce tcp connections, memory and CPU
        /// </summary>
        protected static HttpClient client = new HttpClient();

        protected static void SetInformation()
        {
            if (client.BaseAddress == null)
            {
                client.BaseAddress = new Uri("http://localhost:57486");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }
    }
}
