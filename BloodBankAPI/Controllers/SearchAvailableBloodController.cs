using BloodBank.BusinessLogic;
using BloodBank.Comman;
using BloodBank.DataAccess;
using BloodBank.Properties;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Serialization;


namespace BloodBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchAvailableBloodController : ControllerBase
    {
        public readonly AppDb _appDb;

        public SearchAvailableBloodController(AppDb appDb)
        {
            _appDb= appDb;
        }

        [HttpPost]
        public async Task<IActionResult> SearchAvailableBlood(Request objRequest)
        {
            if (objRequest == null)
            {
                return BadRequest("Request cannot be null");
            }

            try
            {
                string strRequestType = Request.ContentType;

                SearchAvailableBloodBAL objSearchAvailableBloodBAL = new SearchAvailableBloodBAL(_appDb);
                var result = await objSearchAvailableBloodBAL.SearchAvailableBlood(objRequest);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }


    }
}
