using TestCompany.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCompany.Core.DataLayer
{
    public abstract class ShopDataAccess
    {
        public abstract IList<IShop> GetAll();

        public abstract IShop Get(int id);

        public abstract IList<IShop> GetByDistrict(int districtId);

        public abstract bool Update(int id, string name);

        public abstract int Insert(string name);

        public abstract bool Delete(int id);
    }
}
