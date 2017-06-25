using NeasEnergy.Core.Client.Exceptions;
using NeasEnergy.Core.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NeasEnergy.Core.Client
{
    public class DistrictSellerController : BaseController
    {
        public static async Task<bool> InsertAsync(int sellerId, int districtId, bool isPrimary)
        {
            SetInformation();

            var model = new 
            {
                sellerId = sellerId,
                districtId = districtId,
                isPrimary = isPrimary
            };

            var response = await client.PostAsJsonAsync("/api/districtseller", model).ConfigureAwait(false); // fix deadlock

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public static async Task<bool> DeleteAsync(int sellerId, int districtId)
        {
            SetInformation();

            var model = new
            {
                sellerId = sellerId,
                districtId = districtId
            };

            var response = await client.DeleteAsync(string.Format("/api/districtseller/?sellerId={0}&districtId={1}", sellerId, districtId)).ConfigureAwait(false); // fix deadlock

            if (response.IsSuccessStatusCode)
            {
                return true;
            } else
            {
                throw new ServiceException(response.Content.ReadAsStringAsync().Result);
            }
        }

        public static async Task<bool> UpdateAsync(int sellerId, int districtId, bool isPrimary)
        {
            SetInformation();

            var model = new
            {
                sellerId = sellerId,
                districtId = districtId,
                isPrimary = isPrimary
            };

            var response = await client.PutAsJsonAsync("/api/districtseller", model).ConfigureAwait(false); // fix deadlock

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}
