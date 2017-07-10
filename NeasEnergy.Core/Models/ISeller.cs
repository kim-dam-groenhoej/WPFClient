using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCompany.Core.Models
{
    public interface ISeller
    {
        int Id { get; set; }
        string Name { get; set; }

        string Phone { get; set; }

        string Email { get; set; }

        bool IsPrimary { get; set; }

        DateTime Created { get; set; }

        DateTime Updated { get; set; }
    }
}
