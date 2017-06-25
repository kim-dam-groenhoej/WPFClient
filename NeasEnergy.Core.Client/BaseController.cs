using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NeasEnergy.Core.Client
{
    public class BaseController
    {
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
