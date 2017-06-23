using NeasEnergy.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeasEnergy.Core.DataLayer
{
    public abstract class DistrictSellerDataAccess
    {
        public abstract IDistrictSeller Get(int sellerId, int districtId);

        public abstract IList<IDistrictSeller> GetAll();

        public abstract IList<IDistrictSeller> GetByDistrict(int districtId);

        public abstract IList<IDistrictSeller> GetBySeller(int sellerid);

        public abstract int Insert(int sellerId, int districtId, bool isPrimary);

        public abstract bool Delete(int id);
    }
}
