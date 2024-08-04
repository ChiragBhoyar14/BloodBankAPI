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
        public async Task<IActionResult> SearchAvailableBloodDoner(Request objRequest)
        {
            Response<List<SearchAvailableBloodDonerListDTO>> objResponse = new Response<List<SearchAvailableBloodDonerListDTO>>();
            SearchAvailableBloodDonerBAL objSearchAvailableBloodDonerBAL = null;


            try
            {
                if (objRequest == null)
                {
                    objResponse.StatusCode = (int)StatusCodes.Status400BadRequest; 
                    objResponse.Status = "Invalid Request";

                    return BadRequest(objResponse);
                }
                else
                {
                    objSearchAvailableBloodDonerBAL =new SearchAvailableBloodDonerBAL(_appDb);
                    var result = await objSearchAvailableBloodDonerBAL.SearchAvailableBloodDoner(objRequest);

                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                objResponse.StatusCode = (int)StatusCodes.Status500InternalServerError;
                objResponse.Status = "An error occurred while processing your request: " + ex.Message;
                objResponse.Data = null;

                return StatusCode((int)StatusCodes.Status500InternalServerError,objResponse);
            }
            finally
            {
                objSearchAvailableBloodDonerBAL = null;
            }
           
        }

    }


}

