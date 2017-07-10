using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCompany.Core.Models;
using System.Data.SqlClient;
using TestCompany.Core.DataLayer.Providers.MsSql;

namespace TestCompany.Core.DataLayer.Providers.MsSql
{
    public class MsSqlSellerDataAccess : SellerDataAccess
    {
        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override ISeller Get(int id)
        {
            throw new NotImplementedException();
        }

        public override IList<ISeller> GetAll()
        {
            throw new NotImplementedException();
        }

        public override IList<ISeller> GetByDistrict(int districtId)
        {
            using (var db = new TestCompanyEntities())
            {
                return db.Database.SqlQuery<Seller>("SELECT S.Id, S.name, S.phone, s.email, S.Created, S.Updated, ds.IsPrimary FROM [Seller] S INNER JOIN [DistrictSeller] ds ON S.Id = ds.SellerId WHERE ds.DistrictId = @DistrictId", new SqlParameter("DistrictId", districtId)).ToList<ISeller>();
            }
        }

        public override IList<ISeller> GetByNotInDistrict(int districtId)
        {
            using (var db = new TestCompanyEntities())
            {
                return db.Database.SqlQuery<Seller>("SELECT S.Id, S.name, S.phone, s.email, S.Created, S.Updated, CASE WHEN ds.IsPrimary IS NULL THEN CAST(1 AS BIT) ELSE ds.IsPrimary END AS IsPrimary FROM [Seller] S LEFT JOIN  [DistrictSeller] ds ON S.Id = ds.SellerId WHERE (ds.DistrictId <> @DistrictId OR ds.DistrictId IS NULL) AND S.ID NOT IN (SELECT S.Id FROM [Seller] S LEFT JOIN  [DistrictSeller] ds ON S.Id = ds.SellerId WHERE ds.DistrictId = @DistrictId)", new SqlParameter("DistrictId", districtId)).ToList<ISeller>();
            }
        }

        public override int Insert(string name, string phone, string email)
        {
            throw new NotImplementedException();
        }

        public override bool Update(int id, string name, string phone, string email)
        {
            throw new NotImplementedException();
        }
    }
}
