using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeasEnergy.Core.Models
{
    public interface ISeller
    {
        string Name { get; set; }

        string Phone { get; set; }

        string Email { get; set; }

        DateTime Created { get; set; }

        DateTime Updated { get; set; }
    }
}
