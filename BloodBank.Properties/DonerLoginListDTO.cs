using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Properties
{
    public class DonerLoginListDTO
    {
        public DonerLoginListDTO()
        {
            DonerCredentialId = 0;
            Name = string.Empty;    
            Role = string.Empty;
        }

        public int DonerCredentialId {get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }
}
