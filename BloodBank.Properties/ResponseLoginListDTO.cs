using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Properties
{
    public class ResponseLoginListDTO
    {
        public ResponseLoginListDTO()
        {
            JWTToken = string.Empty;
        }
        public string  JWTToken { get; set; }
    }
}
