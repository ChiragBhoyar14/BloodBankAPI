using BloodBank.IRepository;
using BloodBank.Properties;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetCityByStateIdController : ControllerBase
    {
        private readonly IBloodDoner _ibloodDoner;

        public GetCityByStateIdController(IBloodDoner bloodDoner)
        {
            _ibloodDoner = bloodDoner;
        }

        [HttpPost]
        public async Task<IActionResult> GetCityByStateId([FromBody] StatelistDTO objStatelistDTO)
        {

            var Result = await _ibloodDoner.GetCity(objStatelistDTO.StateId);

            return Ok(Result);
        }
    }
}
