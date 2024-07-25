using BloodBank.Comman;
using BloodBank.DataAccess;
using BloodBank.Properties;
using System.Collections.Generic;


namespace BloodBank.BusinessLogic
{
    public class SearchAvailableBloodDonerBAL
    {
        public readonly AppDb _appDb;

        public SearchAvailableBloodDonerBAL(AppDb appDb)
        {
            _appDb = appDb;
        }

        public async Task<Response<List<SearchAvailableBloodDonerListDTO>>> SearchAvailableBloodDoner(Request objRequest)
        {
            SearchAvailableBloodDonerDAL objSearchAvailableBloodDonerDAL = null;
            List<SearchAvailableBloodDonerListDTO> lstSearchAvailableBloodDonerListDTO = null;
            Response<List<SearchAvailableBloodDonerListDTO>> objResponse = new Response<List<SearchAvailableBloodDonerListDTO>>();


            try
            {

                objSearchAvailableBloodDonerDAL = new SearchAvailableBloodDonerDAL(_appDb);

                lstSearchAvailableBloodDonerListDTO = await objSearchAvailableBloodDonerDAL.AvailableBloodDoner(objRequest);


                if (lstSearchAvailableBloodDonerListDTO != null && lstSearchAvailableBloodDonerListDTO.Count > 0)
                {
                    objResponse.StatusCode = 200;
                    objResponse.Status = "Sucess";
                    objResponse.Data = lstSearchAvailableBloodDonerListDTO;
                }
                else
                {
                    objResponse.StatusCode = 204;
                    objResponse.Status = "No Data Available";
                    objResponse.Data = null;
                }



            }
            catch (Exception ex)
            {
                objResponse.StatusCode = 500;
                objResponse.Status = "An error occurred while processing your request: " + ex.Message;
                objResponse.Data = null;
            }
            finally
            {
                lstSearchAvailableBloodDonerListDTO = null;
                objSearchAvailableBloodDonerDAL = null;
            }

            return objResponse;

        }

    }
}
