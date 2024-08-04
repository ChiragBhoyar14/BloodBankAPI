using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Properties
{
    public class SearchAvailableBloodDonerListDTO
    {
        public long DonerId { get; set; }
        public string DonarName { get; set; }
        public string BloodGroup { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public bool IsPublished { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastDonationDate { get; set; }
        public string Address { get; set; }
        public string HighSugarStatus { get; set; }
        public string HighBPStatus { get; set; }

        public SearchAvailableBloodDonerListDTO()
        {
            DonerId = 0;
            DonarName = string.Empty;
            BloodGroup = string.Empty;
            Mobile = string.Empty;
            Email = string.Empty;
            City = string.Empty;
            State = string.Empty;
            DateOfBirth = DateTime.MinValue;
            Gender = string.Empty;
            RegisterDate = DateTime.MinValue;
            IsPublished = false;
            LastDonationDate = DateTime.MinValue;
            Address = string.Empty;
            HighSugarStatus = string.Empty;
            HighBPStatus = string.Empty;
        }

    }

}
