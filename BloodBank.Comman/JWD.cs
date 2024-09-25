using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Comman
{
    public class JWD
    {

        public string Key { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public double ExpiryTime { get; set; }
    }
}
