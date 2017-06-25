﻿using NeasEnergy.Core.Client.Exceptions;
using NeasEnergy.Core.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace NeasEnergy.Core.Client
{
    public class SellerController : BaseController
    {
        public static async Task<IEnumerable<ISeller>> GetByDistrictAsync(int districtId)
        {
            SetInformation();

            IEnumerable<ISeller> sellers = new List<ISeller>();
            var response = await client.GetAsync(string.Format("/api/Seller/InDistrict/?id={0}", districtId)).ConfigureAwait(false); // fix deadlock

            if (response.IsSuccessStatusCode)
            {
                var formatters = new List<MediaTypeFormatter>() {
                    new JsonMediaTypeFormatter(),
                    new XmlMediaTypeFormatter()
                };

                var result = await response.Content.ReadAsAsync<IEnumerable<Seller>>(formatters);
                sellers = result;
            } else
            {
                throw new ServiceException(string.Format("Error loading sellers - statuscode {0}", response.StatusCode));
            }

            return sellers;
        }

        public static async Task<IEnumerable<ISeller>> GetByNotInDistrictAsync(int districtId)
        {
            SetInformation();

            IEnumerable<ISeller> sellers = new List<ISeller>();
            var response = await client.GetAsync(string.Format("/api/Seller/NotInDistrict/?id={0}", districtId)).ConfigureAwait(false); // fix deadlock

            if (response.IsSuccessStatusCode)
            {
                var formatters = new List<MediaTypeFormatter>() {
                    new JsonMediaTypeFormatter(),
                    new XmlMediaTypeFormatter()
                };

                var result = await response.Content.ReadAsAsync<IEnumerable<Seller>>(formatters);
                sellers = result;
            }
            else
            {
                throw new ServiceException(string.Format("Error loading sellers - statuscode {0}", response.StatusCode));
            }

            return sellers;
        }
    }
}
