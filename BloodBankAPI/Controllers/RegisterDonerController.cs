
using BloodBank.Comman;
using BloodBank.IRepository;
using BloodBank.Properties;
using BloodBank.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterDonerController : ControllerBase
    {
        private readonly IBloodDoner _ibloodDoner;

        public RegisterDonerController(IBloodDoner ibloodDoner)
        {
            _ibloodDoner = ibloodDoner;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterDoner([FromBody]RequestRegisterDonerListDTO objRequestRegisterDonerListDTO)
        {
            Response<List<SearchAvailableBloodDonerListDTO>> objResponse = new Response<List<SearchAvailableBloodDonerListDTO>>();

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

                    var Result = await _ibloodDoner.RegisterDoner(objRequestRegisterDonerListDTO);

                    return Ok(Result);

                }
            }
            catch (Exception ex)
            {
                objResponse.StatusCode = (int)StatusCodes.Status500InternalServerError;
                objResponse.Status = "An error occurred while processing your request: " + ex.Message;

                return StatusCode((int)StatusCodes.Status500InternalServerError, objResponse);

            }
        }
    }
}
