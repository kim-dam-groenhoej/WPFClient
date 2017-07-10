using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCompany.Core.Client.Models
{
    public class DataCollection<T> where T : class
    {
        public List<T> Collection { get; set; }
    }
}
