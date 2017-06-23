using NeasEnergy.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeasEnergy.Core.DataLayer
{
    public abstract class DistrictShopDataAccess
    {
        public abstract IList<IDistrictShop> GetByDistrict(int districtId);

        public abstract IList<IDistrictShop> GetByShop(int shopId);

        public abstract IDistrictShop Get(int districtId, int shopId);

        public abstract int Insert(int districtId, int shopId);

        public abstract bool Delete(int districtId, int shopId);
    }
}
