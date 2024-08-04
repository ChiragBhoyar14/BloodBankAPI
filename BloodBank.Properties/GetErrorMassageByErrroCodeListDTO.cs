using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Properties
{
    public class GetErrorMassageByErrroCodeListDTO
    {
        public long ErrorCode { get; set; }
        public string ErrorMassage { get; set; }
        public long ErrorCodeId { get; set; }

        public GetErrorMassageByErrroCodeListDTO()
        {
            ErrorCode = 0;
            ErrorCodeId = 0;
            ErrorMassage = string.Empty;
        }
    }
}
