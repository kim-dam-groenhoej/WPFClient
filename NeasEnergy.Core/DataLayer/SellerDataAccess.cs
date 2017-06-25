using NeasEnergy.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeasEnergy.Core.DataLayer
{
    public abstract class SellerDataAccess
    {
        public abstract ISeller Get(int id);

        public abstract IList<ISeller> GetAll();

        public abstract IList<ISeller> GetByDistrict(int districtId);
        public abstract IList<ISeller> GetByNotInDistrict(int districtId);

        public abstract bool Update(int id, string name, string phone, string email);

        public abstract int Insert(string name, string phone, string email);

        public abstract bool Delete(int id);
    }
}
