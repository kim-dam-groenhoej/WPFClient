﻿using TestCompany.Core.DataLayer;
using TestCompany.Core.DataLayer.Providers.MsSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCompany.Core.DataLayer.Providers
{
    public class DataProviderManager
    {
        public static ShopDataAccess GetShop(DataProvider provider)
        {
            switch (provider)
            {
                case DataProvider.MsSql:
                    return new MsSqlShopDataAccess();
            }

            return null;
        }

        public static SellerDataAccess GetSeller(DataProvider provider)
        {
            switch (provider)
            {
                case DataProvider.MsSql:
                    return new MsSqlSellerDataAccess();
            }

            return null;
        }

        public static DistrictDataAccess GetDistrict(DataProvider provider)
        {
            switch (provider)
            {
                case DataProvider.MsSql:
                    return new MsSqlDistrictDataAccess();
            }

            return null;
        }

        public static DistrictSellerDataAccess GetDistrictSeller(DataProvider provider)
        {
            switch (provider)
            {
                case DataProvider.MsSql:
                    return new MsSqlDistrictSellerDataAccess();
            }

            return null;
        }
    }
}
