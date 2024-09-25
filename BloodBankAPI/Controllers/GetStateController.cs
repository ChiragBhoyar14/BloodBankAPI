using BloodBank.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetStateController : ControllerBase
    {

        private readonly IBloodDoner _ibloodDoner;


        public GetStateController(IBloodDoner ibloodDoner)
        {
            _ibloodDoner = ibloodDoner;
        }

        [HttpGet]
        public async Task<IActionResult> GetState()
        {

            var Result = await _ibloodDoner.GetState();

            return Ok(Result);
        }
    }
}
