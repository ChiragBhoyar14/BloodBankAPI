using BloodBank.BusinessLogic;
using BloodBank.Comman;
using BloodBank.Properties;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterDonerController : ControllerBase
    {
        private readonly AppDb _appDb;

        public RegisterDonerController(AppDb appDb)
        {
            _appDb = appDb;
        }

        public async Task<IActionResult> RegisterDoner(RequestRegisterDonerListDTO objRequestRegisterDonerListDTO)
        {
            Response<List<SearchAvailableBloodDonerListDTO>> objResponse = new Response<List<SearchAvailableBloodDonerListDTO>>();
            RegisterDonerBAL objRegisterDonerBAL = null;

            try
            {
                if (objRequestRegisterDonerListDTO == null)
                {
                    objResponse.StatusCode = (int)StatusCodes.Status400BadRequest;
                    objResponse.Status = "Invalid Request";

                    return BadRequest(objResponse);
                }
                else
                {
                    objRegisterDonerBAL = new RegisterDonerBAL(_appDb);

                    var Result = await objRegisterDonerBAL.RegisterDoner(objRequestRegisterDonerListDTO);

                    return Ok(Result);

                }
            }
            catch (Exception ex)
            {
                objResponse.StatusCode = (int)StatusCodes.Status500InternalServerError;
                objResponse.Status = "An error occurred while processing your request: " + ex.Message;

                return StatusCode((int)StatusCodes.Status500InternalServerError, objResponse);

            }
            finally
            {
                objRegisterDonerBAL = null;
            }

        }
    }
}
