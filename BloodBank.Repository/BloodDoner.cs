﻿using BloodBank.IRepository;
using BloodBank.Properties;
using BloodBank.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBank.Comman;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace BloodBank.Repository
{
    public class BloodDoner : IBloodDoner
    {
        private readonly AppDb _appDb;
        private readonly JWD _jwd;


        public BloodDoner(IOptions<AppDb> appDb, IOptions<JWD> jwd)
        {
            _appDb = appDb.Value;
            _jwd = jwd.Value;
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

        public async Task<Response<ResponseLoginListDTO>> LoginDoner(LoginListDTO objLoginListDto)
        {
            DonerLoginBAL objDonerLoginBAL = new DonerLoginBAL(_appDb, _jwd);
            return await objDonerLoginBAL.DonerLogin(objLoginListDto);
        }

        public async Task<List<CityListDTO>> GetCity(long StateID)
        {
            RegisterDonerBAL objRegisterDonerBAL = new RegisterDonerBAL(_appDb);
            return await objRegisterDonerBAL.GetCity(StateID);
        }
        public async Task<List<GetBloodGroupListDTO>> BloodGroup()
        {
            RegisterDonerBAL objRegisterDonerBAL = new RegisterDonerBAL(_appDb);
            return await objRegisterDonerBAL.BloodGroup();
        }

        public async Task<List<StatelistDTO>> GetState()
        {
            RegisterDonerBAL objRegisterDonerBAL = new RegisterDonerBAL(_appDb);
            return await objRegisterDonerBAL.GetState();

        }
    }
}
