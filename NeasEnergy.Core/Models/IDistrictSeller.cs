using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCompany.Core.Models
{
    public interface IDistrictSeller
    {
        int DistrictId { get; set; }

        int SellerId { get; set; }

        DateTime Created { get; set; }

        DateTime Updated { get; set; }
        bool IsPrimary { get; set; }
    }
}
