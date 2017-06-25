using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeasEnergy.Core.Client.Models
{
    public interface IShop
    {
        int Id { get; set; }

        string Name { get; set; }
        DateTime Created { get; set; }

        DateTime Updated { get; set; }

    }
}
