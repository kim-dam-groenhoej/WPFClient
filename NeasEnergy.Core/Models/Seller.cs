using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeasEnergy.Core.Models
{
    public class Seller : ISeller
    {
        public DateTime Created
        {
            get;set;
        }

        public string Email
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string Phone
        {
            get; set;
        }

        public DateTime Updated
        {
            get; set;
        }
    }
}
