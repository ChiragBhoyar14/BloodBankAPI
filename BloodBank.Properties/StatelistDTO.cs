using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Properties
{
    public class StatelistDTO
    {
        public long StateId { get; set; }
        public string State { get; set; }

        public StatelistDTO()
        {
            State = string.Empty;
            StateId = 0;
        }
    }
}
