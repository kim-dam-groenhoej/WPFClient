using TestCompany.Core.DataLayer;
using TestCompany.Core.DataLayer.Providers;
using TestCompany.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestCompany.WebApiService.Controllers
{
    [RoutePrefix("api/Seller")]
    public class SellerController : ApiController
    {
        private SellerDataAccess sellerDataAccess;

        public SellerController()
        {
            this.sellerDataAccess = DataProviderManager.GetSeller(DataProvider.MsSql);
        }

        /// <summary>
        /// Get all sellers by district
        /// </summary>
        /// <param name="id">DistrictID</param>
        /// <returns></returns>
        [Route("InDistrict")]
        public IEnumerable<ISeller> GetByDistrict(int id)
        {
            return this.sellerDataAccess.GetByDistrict(id);
        }

        /// <summary>
        /// Get all sellers is not in district
        /// </summary>
        /// <param name="id">DistrictID</param>
        /// <returns></returns>
        [Route("NotInDistrict")]
        public IEnumerable<ISeller> GetByNotInDistrict(int id)
        {
            return this.sellerDataAccess.GetByNotInDistrict(id);
        }
    }
}
