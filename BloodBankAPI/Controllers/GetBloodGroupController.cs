using BloodBank.IRepository;
using BloodBank.Properties;
using BloodBank.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetBloodGroupController : ControllerBase
    {
        private readonly IBloodDoner _ibloodDoner;

        public GetBloodGroupController(IBloodDoner ibloodDoner)
        {
            _ibloodDoner = ibloodDoner;

        }

        [HttpGet]
        public async Task<IActionResult> GetBloodGroup()
        { 

            var Result = await _ibloodDoner.BloodGroup();

            return Ok(Result);
        }

    }
}
