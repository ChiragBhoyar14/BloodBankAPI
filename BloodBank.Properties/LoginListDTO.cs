using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Properties
{
    public class LoginListDTO
    {
        public LoginListDTO()
        {
            UserName = string.Empty;
            Password = string.Empty;
        }

        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
