using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Properties
{
    public class RequestRegisterDonerListDTO
    {
        public RequestRegisterDonerListDTO()
        {
            Name = string.Empty;
            DateOfBirth = DateTime.MinValue;
            Gender = string.Empty ;
            Mobile = string.Empty ;
            Email = string.Empty ;
            Address = string.Empty ;
            LastDonationDate = null ;
            HighSugarStatus  = string.Empty ;
            HighBPStatus = string.Empty ;
            BloodGroup = string.Empty ;
            State = string.Empty ;
        }

        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime? LastDonationDate { get; set; }
        public string HighSugarStatus { get; set; }
        public string HighBPStatus { get; set; }
        public string BloodGroup { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}
