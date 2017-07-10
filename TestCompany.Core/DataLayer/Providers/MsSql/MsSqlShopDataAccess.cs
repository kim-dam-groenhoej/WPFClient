using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCompany.Core.Models;
using System.Data.SqlClient;

namespace TestCompany.Core.DataLayer.Providers.MsSql
{
    public class MsSqlShopDataAccess : ShopDataAccess
    {
        public override bool Delete(int id)
        {
            using (var db = new TestCompanyEntities())
            {
                return db.Database.ExecuteSqlCommand("DELETE FROM [Shop] WHERE ID = @id", new SqlParameter("id", id)) > 0;
            }
        }

        public override IShop Get(int id)
        {
            using (var db = new TestCompanyEntities())
            {
                return db.Database.SqlQuery<Shop>("SELECT FROM [Shop] WHERE ID = @id", new SqlParameter("id", id)).FirstOrDefault();
            }
        }

        public override IList<IShop> GetAll()
        {
            using (var db = new TestCompanyEntities())
            {
                return db.Database.SqlQuery<Shop>("SELECT * FROM [Shop]").ToList<IShop>();
            }
        }

        public override IList<IShop> GetByDistrict(int districtId)
        {
            using (var db = new TestCompanyEntities())
            {
                return db.Database.SqlQuery<Shop>("SELECT S.Id, S.name, S.Created, S.Updated FROM [Shop] S INNER JOIN [DistrictShop] ds ON S.Id = ds.ShopId WHERE ds.DistrictId = @DistrictId", new SqlParameter("districtId", districtId)).ToList<IShop>();
            }
        }

        public override int Insert(string name)
        {
            using (var db = new TestCompanyEntities())
            {
                return Convert.ToInt32(db.Database.SqlQuery<decimal>("INSERT INTO [Shop] (Name) VALUES(@name);SELECT SCOPE_IDENTITY();", new SqlParameter("name", name)).FirstOrDefault());
            }
        }

        public override bool Update(int id, string name)
        {
            using (var db = new TestCompanyEntities())
            {
                return db.Database.ExecuteSqlCommand("UPDATE FROM [Shop] SET name = @name WHERE ID = @id", new SqlParameter("id", id), new SqlParameter("name", name)) > 0;
            }
        }
    }
}
