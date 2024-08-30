using BloodBank.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.IRepository
{
    public interface IBloodDoner
    {

        Task<Response<string>> RegisterDoner(RequestRegisterDonerListDTO objRequestRegisterDonerListDTO);

        Task<Response<List<SearchAvailableBloodDonerListDTO>>> SearchAvailableBloodDoner(Request objRequest);

        Task<Response<ResponseLoginListDTO>> LoginDoner(LoginListDTO objLoginListDto);

        Task<List<CityListDTO>> GetCity(long StateID);

        Task<List<GetBloodGroupListDTO>> BloodGroup();

        Task<List<StatelistDTO>> GetState();
    }
}
