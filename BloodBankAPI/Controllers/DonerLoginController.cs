using BloodBank.Comman;
using BloodBank.IRepository;
using BloodBank.Properties;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DonerLoginController : ControllerBase
    {
        private readonly IBloodDoner _ibloodDoner;


        public DonerLoginController(IBloodDoner ibloodDoner)
        {
            _ibloodDoner = ibloodDoner;
        }

        [HttpPost]
        public async Task<IActionResult> DonerLogin(LoginListDTO objLoginListDTO)
        {
            Response<List<ResponseLoginListDTO>> objResponse = new Response<List<ResponseLoginListDTO>>();

            try
            {
                if (objLoginListDTO == null)
                {
                    objResponse.StatusCode = (int)StatusCodes.Status400BadRequest;
                    objResponse.Status = "Invalid Request";

                    return BadRequest(objResponse);
                }
                else
                {

                    var Result = await _ibloodDoner.LoginDoner(objLoginListDTO);

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

