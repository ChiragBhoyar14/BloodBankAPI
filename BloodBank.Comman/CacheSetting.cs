using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Comman
{
    public class CacheSetting
    {
        public int SlidingExpiration { get; set; }
        public int AbsoluteExpiration { get; set; }

    }

    public class CaheKey
    {
        public static readonly string StateCache = "State";
        public static readonly string BloodGroupCache = "BloodGroup"; 
    }
}
