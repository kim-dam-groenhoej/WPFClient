﻿using NeasEnergy.Core.DataLayer;
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
    [RoutePrefix("api/Seller")]
    public class SellerController : ApiController
    {
        private SellerDataAccess sellerDataAccess;

        public SellerController()
        {
            this.sellerDataAccess = DataProviderManager.GetSeller(DataProvider.MsSql);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">DistrictID</param>
        /// <returns></returns>
        [Route("InDistrict")]
        public IEnumerable<ISeller> GetByDistrict(int id)
        {
            return this.sellerDataAccess.GetByDistrict(id);
        }

        [Route("NotInDistrict")]
        public IEnumerable<ISeller> GetByNotInDistrict(int id)
        {
            return this.sellerDataAccess.GetByNotInDistrict(id);
        }
    }
}