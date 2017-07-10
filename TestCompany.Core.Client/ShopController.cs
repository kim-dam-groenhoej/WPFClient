using TestCompany.Core.Client.Exceptions;
using TestCompany.Core.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TestCompany.Core.Client
{
    public class ShopController : BaseController
    {
        public static async Task<IShop> GetAsync()
        {
            SetInformation();

            Shop shop = null;
            HttpResponseMessage response = await client.GetAsync("shop");
            if (response.IsSuccessStatusCode)
            {
                shop = await response.Content.ReadAsAsync<Shop>();
            }

            return shop;
        }

        public static async Task<IEnumerable<IShop>> GetByDistrictAsync(int districtId)
        {
            SetInformation();
            IEnumerable<IShop> shops = new List<IShop>();

            var response = await client.GetAsync(string.Format("/api/shop/{0}", districtId)).ConfigureAwait(false); // fix deadlock
            if (response.IsSuccessStatusCode)
            {
                var formatters = new List<MediaTypeFormatter>() {
                    new JsonMediaTypeFormatter(),
                    new XmlMediaTypeFormatter()
                };

                shops = await response.Content.ReadAsAsync<IEnumerable<Shop>>(formatters);
            }
            else
            {
                throw new ServiceException(string.Format("Error loading sellers - statuscode {0}", response.StatusCode));
            }

            return shops;
        }
    }
}
