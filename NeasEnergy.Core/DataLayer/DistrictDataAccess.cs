using NeasEnergy.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeasEnergy.Core.DataLayer
{
    public abstract class DistrictDataAccess
    {
        public abstract IDistrict Get(int id);

        public abstract IList<IDistrict> GetAll();

        public abstract IList<IDistrict> GetByShop(int shopId);

        public abstract bool Update(int id, string name);

        public abstract int Insert(string name, ISeller primarySeller);

        public abstract bool Delete(int id);
    }
}
