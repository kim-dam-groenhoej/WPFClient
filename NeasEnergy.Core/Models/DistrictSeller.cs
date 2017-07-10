﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCompany.Core.Models
{
    public class DistrictSeller : IDistrictSeller
    {
        public DateTime Created
        {
            get;set;
        }

        public int DistrictId
        {
            get; set;
        }

        public int SellerId
        {
            get; set;
        }

        public DateTime Updated
        {
            get; set;
        }

        public bool IsPrimary
        {
            get; set;
        }
    }
}
