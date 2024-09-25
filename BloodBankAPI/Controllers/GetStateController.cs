using BloodBank.Comman;
using BloodBank.IRepository;
using BloodBank.Properties;
using LazyCache;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace BloodBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetStateController : ControllerBase
    {

        private readonly IBloodDoner _ibloodDoner;
        private ICacheProvider _cacheProvider;
        private CacheSetting _CacheSetting;

        public GetStateController(IBloodDoner ibloodDoner,ICacheProvider cacheProvider, IOptions<CacheSetting> cacheSetting)
        {
            _ibloodDoner = ibloodDoner;
            _cacheProvider = cacheProvider;
            _CacheSetting = cacheSetting.Value;
        }

        [HttpGet]
        public async Task<IActionResult> GetState()
        
        {
            if (!_cacheProvider.TryGetValue(CaheKey.StateCache, out List<StatelistDTO> lstStatelistDTO))
            {
                lstStatelistDTO = await _ibloodDoner.GetState();

                var CacheEntryOption = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddSeconds(_CacheSetting.AbsoluteExpiration),
                    SlidingExpiration = TimeSpan.FromSeconds(_CacheSetting.SlidingExpiration),
                    Size = 5120
                };

                _cacheProvider.Set(CaheKey.StateCache, lstStatelistDTO, CacheEntryOption);

            }
            return Ok(lstStatelistDTO);
        }
    }
}
