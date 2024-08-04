using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Properties
{
    public class GetBloodGroupListDTO
    {
        public int BloodGroupId { get; set; }
        public string BloodGroup { get;set; }

        public GetBloodGroupListDTO()
        {
            BloodGroupId = 0;  
            BloodGroup = string.Empty;
        }
    }
}
