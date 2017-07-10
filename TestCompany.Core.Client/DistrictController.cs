using TestCompany.Core.Client.Exceptions;
using TestCompany.Core.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace TestCompany.Core.Client
{
    public class DistrictController : BaseController
    {
        public static async Task<IEnumerable<IDistrict>> GetAsync()
        {
            SetInformation();
            IEnumerable<IDistrict> districts = new List<District>();

            var response = await client.GetAsync("/api/district").ConfigureAwait(false); // fix deadlock
            if (response.IsSuccessStatusCode)
            {
                var formatters = new List<MediaTypeFormatter>() {
                    new JsonMediaTypeFormatter(),
                    new XmlMediaTypeFormatter()
                };

                districts = await response.Content.ReadAsAsync<IEnumerable<District>>(formatters);
            } else {
                throw new ServiceException(string.Format("Error loading sellers - statuscode {0}", response.StatusCode));
            }

            return districts;
        }
        
    }
}
