using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Properties
{
    public class AvailableBloodListDTO
    {
        public string DonerId {get;set;}
        public string DonarName   {get;set;}
        public string BloodGroup {get;set;}
        public string Mobile  {get;set;}
        public string Email  {get;set;}
        public string City   {get;set;}
        public bool Status {get;set;}
        public DateTime RegisterDate { get; set; }
    }
}
