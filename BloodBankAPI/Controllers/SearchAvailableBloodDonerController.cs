using BloodBank.BusinessLogic;
using BloodBank.Comman;
using BloodBank.DataAccess;
using BloodBank.Properties;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Serialization;


namespace BloodBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchAvailableBloodDonerController : ControllerBase
    {
        public readonly AppDb _appDb;

        public SearchAvailableBloodDonerController(AppDb appDb)
        {
            _appDb = appDb;
        }

        [HttpPost]
        public async Task<ActionResult<Response<List<SearchAvailableBloodDonerListDTO>>>> SearchAvailableBloodDoner(Request objRequest)
        {
            Response<List<SearchAvailableBloodDonerListDTO>> objResponse = new Response<List<SearchAvailableBloodDonerListDTO>>();
            SearchAvailableBloodDonerBAL objSearchAvailableBloodDonerBAL = new SearchAvailableBloodDonerBAL(_appDb);


            try
            {
                if (objRequest == null)
                {
                    objResponse.StatusCode = 400; 
                    objResponse.Status = "Invalid Request";
                    objResponse.Data = null;

                    return objResponse;
                }
                else
                {                
                    var result = await objSearchAvailableBloodDonerBAL.SearchAvailableBloodDoner(objRequest);

                      return result;
                    
                }
            }
            catch (Exception ex)
            {
                objResponse.StatusCode = 500;
                objResponse.Status = "An error occurred while processing your request: " + ex.Message;
                objResponse.Data = null;

                return objResponse;
            }
            finally
            {
                objSearchAvailableBloodDonerBAL = null;
            }
           
        }

    }


}

