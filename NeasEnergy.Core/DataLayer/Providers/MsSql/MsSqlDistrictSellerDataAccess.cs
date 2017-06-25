using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeasEnergy.Core.Models;
using System.Data.SqlClient;

namespace NeasEnergy.Core.DataLayer.Providers.MsSql
{
    public class MsSqlDistrictSellerDataAccess : DistrictSellerDataAccess
    {
        public override bool Delete(int sellerId, int districtId)
        {
            using (var db = new NeasEnergyEntities1())
            {
                return db.Database.ExecuteSqlCommand("DeleteDistrictSeller @sellerId, @districtId", new SqlParameter("districtId", districtId), new SqlParameter("sellerId", sellerId)) > 0;
            }
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

        public override bool Insert(int sellerId, int districtId, bool isPrimary)
        {
            using (var db = new NeasEnergyEntities1())
            {
                return db.Database.ExecuteSqlCommand("INSERT INTO [DistrictSeller] (DistrictId, SellerId, IsPrimary) VALUES(@DistrictId, @SellerId, @IsPrimary);", new SqlParameter("DistrictId", districtId), new SqlParameter("SellerId", sellerId), new SqlParameter("IsPrimary", isPrimary)) > 0;
            }
        }

        public override bool Update(int sellerId, int districtId, bool isPrimary)
        {
            using (var db = new NeasEnergyEntities1())
            {
                return db.Database.ExecuteSqlCommand("UpdateDistrictSeller @sellerId, @isPrimary, @districtId", new SqlParameter("districtId", districtId), new SqlParameter("sellerId", sellerId), new SqlParameter("isPrimary", isPrimary)) > 0;
            }
        }
    }
}
