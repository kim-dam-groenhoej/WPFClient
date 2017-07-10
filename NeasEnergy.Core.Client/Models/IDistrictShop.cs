using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCompany.Core.Client.Models
{
    public interface IDistrictShop
    {
        int DistrictId { get; set; }

        int ShopId { get; set; }

        DateTime Created { get; set; }

        DateTime Updated { get; set; }
    }
}
