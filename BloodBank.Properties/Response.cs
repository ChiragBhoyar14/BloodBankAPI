using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Properties
{
    public class Response <T>
    {
        public int StatusCode { get; set; }
        public string Status {  get; set; }
        public T Data { get; set; }

    }
}
