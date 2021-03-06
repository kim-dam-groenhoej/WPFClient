﻿using TestCompany.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCompany.Core.DataLayer
{
    public abstract class DistrictSellerDataAccess
    {
        public abstract IDistrictSeller Get(int sellerId, int districtId);

        public abstract IList<IDistrictSeller> GetAll();

        public abstract IList<IDistrictSeller> GetByDistrict(int districtId);

        public abstract IList<IDistrictSeller> GetBySeller(int sellerid);

        public abstract bool Insert(int sellerId, int districtId, bool isPrimary);

        public abstract bool Update(int sellerId, int districtId, bool isPrimary);

        public abstract bool Delete(int sellerId, int districtId);
    }
}
