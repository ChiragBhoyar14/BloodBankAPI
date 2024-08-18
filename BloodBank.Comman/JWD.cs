using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Comman
{
    public class JWD
    {
        public JWD(string key, string audience, string issuer, string expiryTime)
        {
            Key = key;
            Audience = audience;
            Issuer = issuer;
            ExpiryTime = Convert.ToDouble(expiryTime);
        }

        public string Key { get;private set; }
        public string Audience { get; private set; }
        public string Issuer { get; private set; }
        public double ExpiryTime { get; private set; }
    }
}
