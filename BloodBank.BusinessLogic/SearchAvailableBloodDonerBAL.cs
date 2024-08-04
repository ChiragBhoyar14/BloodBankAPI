using BloodBank.Comman;
using BloodBank.DataAccess;
using BloodBank.Properties;
using System.Text.RegularExpressions;


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

            long Error = 0;
            SearchAvailableBloodDonerDAL objSearchAvailableBloodDonerDAL = null;
            List<SearchAvailableBloodDonerListDTO> lstSearchAvailableBloodDonerListDTO = null;
            Response<List<SearchAvailableBloodDonerListDTO>> objResponse = new Response<List<SearchAvailableBloodDonerListDTO>>();
            List<GetBloodGroupListDTO> lstGetBloodGroupListDTO = null;
            List<StatelistDTO> lstStatelistDTO = null;
            List<CityListDTO> lstCityListDTO = null;
            List<GetErrorMassageByErrroCodeListDTO> lstGetErrorMassageByErrroCode = null;
            ErrorCodeDAL objErrorCodeDAL = null;




            try
            {
                objSearchAvailableBloodDonerDAL = new SearchAvailableBloodDonerDAL(_appDb);

                if (Error == 0)
                {

                    if (objRequest.BloodGroupId > 0)
                    {
                        lstGetBloodGroupListDTO = await objSearchAvailableBloodDonerDAL.GetBloodGroup();

                        if(lstGetBloodGroupListDTO != null && lstGetBloodGroupListDTO.Count> 0)
                        {
                            bool exists = lstGetBloodGroupListDTO.Any(x => x.BloodGroupId == objRequest.BloodGroupId);

                            if (!exists)
                            {
                                Error = 1;
                            }
                        }
                    }
                }

                if (Error == 0) { 
                
                    if (objRequest.Name != null) {
                        if (!Regex.IsMatch(objRequest.Name, "^[a-zA-Z\\s]+$"))
                        {
                            Error = 2;
                        }
                    }

                }

                if (Error == 0)
                {
                    if (objRequest.DonerId > 0)
                    {
                        if (objRequest.DonerId < 0)
                        {
                            Error = 3;
                        }
                    }
                }

                if (Error == 0)
                {
                    if (!String.IsNullOrWhiteSpace(objRequest.State))
                    {
                        lstStatelistDTO = await objSearchAvailableBloodDonerDAL.GetState();

                        if (lstStatelistDTO != null && lstStatelistDTO.Count > 0)
                        {
                            var Result = lstStatelistDTO.FirstOrDefault(x => x.State == objRequest.State);

                            if (Result != null)
                            {
                                objRequest.StateId = Result.StateId;
                            }
                            else
                            {
                                Error = 4;
                            }
                        }
                    }
                    else
                    {
                        Error = 9;
                    }
                }

                if (Error == 0)
                {
                    if (objRequest.CityId > 0 && objRequest.StateId > 0)
                    {
                        lstCityListDTO = await objSearchAvailableBloodDonerDAL.GetCityByStateId(objRequest.StateId);

                        if (lstCityListDTO != null && lstCityListDTO.Count > 0)
                        {
                            bool exists = lstCityListDTO.Any(x => x.CityId == objRequest.CityId);

                            if (!exists)
                            {
                                Error = 5;
                            }
                          
                        }
                    }
                }

                if (Error == 0)
                {

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
                    }
                }

                if(Error > 0)
                {
                    objErrorCodeDAL = new ErrorCodeDAL(_appDb);

                    lstGetErrorMassageByErrroCode = objErrorCodeDAL.GetErrorMassageByErrroCode(Error);

                    if(lstGetErrorMassageByErrroCode != null && lstGetErrorMassageByErrroCode.Count > 0)
                    {
                        objResponse.StatusCode = lstGetErrorMassageByErrroCode[0].ErrorCode;
                        objResponse.Status = lstGetErrorMassageByErrroCode[0].ErrorMassage;
                    }
                }
            }
            catch (Exception ex)
            {
                objResponse.StatusCode = 500;
                objResponse.Status = "An error occurred while processing your request: " + ex.Message;
            }
            finally
            {
                lstSearchAvailableBloodDonerListDTO = null;
                objSearchAvailableBloodDonerDAL = null;
                lstGetErrorMassageByErrroCode = null;
                objRequest = null;
                objErrorCodeDAL = null;
            }

            return objResponse;

        }

    }
}
