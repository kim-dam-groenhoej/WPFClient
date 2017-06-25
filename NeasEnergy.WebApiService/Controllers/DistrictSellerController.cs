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
    public class DistrictSellerController : ApiController
    {
        private DistrictSellerDataAccess districtSellerDataAccess;

        public DistrictSellerController()
        {
            this.districtSellerDataAccess = DataProviderManager.GetDistrictSeller(DataProvider.MsSql);
        }

        public IHttpActionResult Put([FromBody]DistrictSeller districtSeller)
        {
            try
            {
                this.districtSellerDataAccess.Update(districtSeller.SellerId, districtSeller.DistrictId, districtSeller.IsPrimary);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }

            return Ok();
        }

        public IHttpActionResult Post([FromBody]DistrictSeller districtSeller)
        {
            try
            {
                this.districtSellerDataAccess.Insert(districtSeller.SellerId, districtSeller.DistrictId, districtSeller.IsPrimary);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }

            return Ok();
        }

        public IHttpActionResult Delete([FromUri]int sellerId, [FromUri]int districtId)
        {
            try
            {
                this.districtSellerDataAccess.Delete(sellerId, districtId);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }

            return Ok();
        }
    }
}
