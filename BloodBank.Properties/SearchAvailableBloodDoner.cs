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

    }

}
