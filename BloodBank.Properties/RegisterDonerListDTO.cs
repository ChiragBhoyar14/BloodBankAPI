using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BloodBank.Properties
{
    public class RegisterDonerListDTO
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public long StateId { get; set; }
        public long CityId { get; set; }
        public int BloodGroupId { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public bool IsPublished { get; set; }
        public string PublishedBy { get; set; }
        public string Address { get; set; }
        public DateTime? LastDonationDate { get; set; }
        public string HighSugarStatus { get; set; }
        public string HighBPStatus { get; set; }
        public DateTime RegisterDate { get; set; }
        public int HighSugarStatusId { get; set; }
        public int HighBPStatusId { get; set; }
        public string BloodGroup { get; set; }
        public string State{ get; set; }
        public string City { get; set; }
        public bool IsAvailable { get; set; }

        public RegisterDonerListDTO()
        {
            Name = string.Empty;
            DateOfBirth = DateTime.MinValue;
            Gender = string.Empty;
            StateId = 0;
            CityId = 0;
            BloodGroupId = 0;
            Mobile = string.Empty;
            Email = string.Empty;
            IsPublished = false;
            PublishedBy = string.Empty;
            Address = string.Empty;
            LastDonationDate = null;
            HighSugarStatus = string.Empty;
            HighBPStatus = string.Empty;
            RegisterDate = DateTime.MinValue;
            HighSugarStatusId = 0;
            HighBPStatusId = 0;
            BloodGroup = string.Empty;
            State = string.Empty;
            City = string.Empty;
            IsAvailable = false;
        }
    }
}
