using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeasEnergy.Core.Models;
using System.Data.SqlClient;

namespace NeasEnergy.Core.DataLayer.Providers.MsSql
{
    public class MsSqlDistrictDataAccess : DistrictDataAccess
    {
        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override IDistrict Get(int id)
        {
            throw new NotImplementedException();
        }

        public override IList<IDistrict> GetAll()
        {
            using (var db = new NeasEnergyEntities1())
            {
                return db.Database.SqlQuery<District>("SELECT * FROM [District]").ToList<IDistrict>();
            }
        }

        public override IList<IDistrict> GetByShop(int shopId)
        {
            using (var db = new NeasEnergyEntities1())
            {
                return db.Database.SqlQuery<District>("SELECT D.Id, D.name, D.Created, D.Updated FROM [District] D INNER JOIN [DistrictShop] ds ON D.Id = ds.DistrictId WHERE ds.ShopId = @shopId", new SqlParameter("shopId", shopId)).ToList<IDistrict>();
            }
        }

        public override int Insert(string name, ISeller primarySeller)
        {
            throw new NotImplementedException();
        }

        public override bool Update(int id, string name)
        {
            throw new NotImplementedException();
        }
    }
}
