using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeasEnergy.Core.Models;

namespace NeasEnergy.Core.DataLayer.Providers.MsSql
{
    public class MsSqlDistrictSellerDataAccess : DistrictSellerDataAccess
    {
        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override IDistrictSeller Get(int sellerId, int districtId)
        {
            throw new NotImplementedException();
        }

        public override IList<IDistrictSeller> GetAll()
        {
            throw new NotImplementedException();
        }

        public override IList<IDistrictSeller> GetByDistrict(int districtId)
        {
            throw new NotImplementedException();
        }

        public override IList<IDistrictSeller> GetBySeller(int sellerid)
        {
            throw new NotImplementedException();
        }

        public override int Insert(int sellerId, int districtId, bool isPrimary)
        {
            throw new NotImplementedException();
        }
    }
}
