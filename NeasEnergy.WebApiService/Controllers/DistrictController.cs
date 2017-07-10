using TestCompany.Core.DataLayer;
using TestCompany.Core.DataLayer.Providers;
using TestCompany.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace TestCompany.WebApiService.Controllers
{
    public class DistrictController : ApiController
    {
        private DistrictDataAccess districtDataAccess;

        public DistrictController()
        {
            this.districtDataAccess = DataProviderManager.GetDistrict(DataProvider.MsSql);
        }

        public IEnumerable<IDistrict> Get()
        {
            return districtDataAccess.GetAll();
        }
    }
}
