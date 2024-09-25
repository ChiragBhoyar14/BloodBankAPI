using BloodBank.Comman;
using BloodBank.IRepository;
using BloodBank.Properties;
using BloodBank.Repository;
using LazyCache;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace BloodBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetBloodGroupController : ControllerBase
    {
        private readonly IBloodDoner _ibloodDoner;
       private ICacheProvider _cacheProvider;

        public GetBloodGroupController(IBloodDoner ibloodDoner, ICacheProvider cacheProvider)
        {
            _ibloodDoner = ibloodDoner;
            _cacheProvider = cacheProvider;

        }

        [HttpGet]
        public async Task<IActionResult> GetBloodGroup()
        {

            if (!_cacheProvider.TryGetValue(CaheKey.BloodGroupCache, out List<GetBloodGroupListDTO> lstGetBloodGroupListDTO))
            {
                lstGetBloodGroupListDTO = await _ibloodDoner.BloodGroup();

                var CacheEntryOption = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddSeconds(20),
                    SlidingExpiration = TimeSpan.FromSeconds(20),
                    Size = 5120
                };

                _cacheProvider.Set(CaheKey.BloodGroupCache, lstGetBloodGroupListDTO, CacheEntryOption);
            }
            return Ok(lstGetBloodGroupListDTO);
        }

    }
}
