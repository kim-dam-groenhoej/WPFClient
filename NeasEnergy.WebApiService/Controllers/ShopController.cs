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
    public class ShopController : ApiController
    {
        private ShopDataAccess shopDataAccess;

        public ShopController()
        {
            this.shopDataAccess = DataProviderManager.GetShop(DataProvider.MsSql);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">DistrictID</param>
        /// <returns></returns>
        public IEnumerable<IShop> Get(int id)
        {
            return this.shopDataAccess.GetByDistrict(id);
        }
    }
}
