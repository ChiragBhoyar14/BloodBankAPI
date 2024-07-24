using BloodBank.Comman;
using BloodBank.DataAccess;
using BloodBank.Properties;
using System.Collections.Generic;


namespace BloodBank.BusinessLogic
{
    public class SearchAvailableBloodBAL
    {
        public readonly AppDb _appDb;

        public SearchAvailableBloodBAL(AppDb appDb)
        {
            _appDb = appDb;
        }

       public async Task<List<AvailableBloodListDTO>> SearchAvailableBlood(Request objRequest)
       {
            SearchAvailableBloodDAL objSearchAvailableBloodDAL = null;
            List<AvailableBloodListDTO> lstAvailableBloodListDTO = null;

            if (objRequest != null)
            {
                try
                {
                    objSearchAvailableBloodDAL = new SearchAvailableBloodDAL(_appDb);

                    lstAvailableBloodListDTO = await objSearchAvailableBloodDAL.AvailableBlood(objRequest);

                     return lstAvailableBloodListDTO;
                    
                }
                catch(Exception ex)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }

    }
}
