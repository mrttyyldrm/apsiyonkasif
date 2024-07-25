using ApsiyonKasif.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApsionKasif.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CityDetailController : ControllerBase
    {
        private readonly IDistrictService _districtService;
        private readonly ICountyService _countyService;
        private readonly ICityService _cityService;

        public CityDetailController(IDistrictService districtService, ICountyService countyService, ICityService cityService)
        {
            _districtService = districtService;
            _countyService = countyService;
            _cityService = cityService;
        }

        [HttpGet]
        [Route("GetDistrictsByCountyId")]
        public async Task<IActionResult> GetDistrictsByCountyIdAsync([FromQuery]int countyId)
        {
            return Ok(await _districtService.GetDistrictsByCountyIdAsync(countyId));
        }
        [HttpGet]
        [Route("GetCityById")]
        public async Task<IActionResult> GetCityByIdAsync([FromQuery] int cityId)
        {
            return Ok(await _cityService.GetByIdAsync(cityId));
        }
        [HttpGet]
        [Route("GetCountiesByCityId")]
        public async Task<IActionResult> GetCountiesByCityIdAsync([FromQuery] int cityId)
        {
            return Ok(await _countyService.GetCountiesByCityIdAsync(cityId));
        }
    }
}
