using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeasEnergy.Core.Models
{
    public class DistrictShop : IDistrictShop
    {
        public DateTime Created
        {
            get; set;
        }

        public int DistrictId
        {
            get; set;
        }

        public int ShopId
        {
            get; set;
        }

        public DateTime Updated
        {
            get; set;
        }
    }
}
