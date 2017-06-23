using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeasEnergy.Core.Models;

namespace NeasEnergy.Core.DataLayer.Providers.MsSql
{
    public class MsSqlDistrictShopDataAccess : DistrictShopDataAccess
    {
        public override bool Delete(int districtId, int shopId)
        {
            throw new NotImplementedException();
        }

        public override IDistrictShop Get(int districtId, int shopId)
        {
            throw new NotImplementedException();
        }

        public override IList<IDistrictShop> GetByDistrict(int districtId)
        {
            throw new NotImplementedException();
        }

        public override IList<IDistrictShop> GetByShop(int shopId)
        {
            throw new NotImplementedException();
        }

        public override int Insert(int districtId, int shopId)
        {
            throw new NotImplementedException();
        }
    }
}
