using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeasEnergy.Core.Models
{
    public interface IShop
    {
        string Name { get; set; }
        DateTime Created { get; set; }

        DateTime Updated { get; set; }
    }
}
