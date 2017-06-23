using NeasEnergy.Core.DataLayer;
using NeasEnergy.Core.DataLayer.Providers;
using NeasEnergy.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NeasEnergy.WebApiService.Controllers
{
    public class DistrictController : ApiController
    {
        private DistrictDataAccess districtDataAccess;
        public DistrictController()
        {
            this.districtDataAccess = DataProviderManager.GetDistrict(DataProvider.MsSql);
        }

        // GET api/values
        public IEnumerable<IDistrict> Get()
        {
            return districtDataAccess.GetAll();
        }
    }
}
