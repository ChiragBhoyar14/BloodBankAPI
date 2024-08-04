using BloodBank.IRepository;
using BloodBank.Properties;
using BloodBank.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBank.Comman;

namespace BloodBank.Repository
{
    public class BloodDoner : IBloodDoner
    {
        private readonly AppDb _appDb;

        public BloodDoner(AppDb appDb)
        {
            _appDb= appDb;
        }

        public async Task<Response<string>> RegisterDoner(RequestRegisterDonerListDTO objRequestRegisterDonerListDTO)
        {
            RegisterDonerBAL objRegisterDonerBAL = new RegisterDonerBAL(_appDb);
            
            return await objRegisterDonerBAL.RegisterDoner(objRequestRegisterDonerListDTO);

        }

        public async Task<Response<List<SearchAvailableBloodDonerListDTO>>> SearchAvailableBloodDoner(Request objRequest)
        {
            SearchAvailableBloodDonerBAL objSearchAvailableBloodDonerBAL = new SearchAvailableBloodDonerBAL(_appDb);

             return await objSearchAvailableBloodDonerBAL.SearchAvailableBloodDoner(objRequest);
        }
    }
}
