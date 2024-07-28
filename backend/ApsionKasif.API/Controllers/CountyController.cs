using ApsiyonKasif.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApsionKasif.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class CountyController : ControllerBase
    {
        private readonly ICountyService _countyService;
        public CountyController(ICountyService countyService)
        {
            _countyService = countyService;
        }

        [HttpGet]
        [Route("{cityId}")]
        public async Task<IActionResult> GetCountiesByCityId(int cityId)
        {
            return Ok(await _countyService.GetCountiesByCityId(cityId));
        }
    }
}
