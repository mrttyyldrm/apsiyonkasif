using ApsiyonKasif.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApsionKasif.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        [Route("Cities")]
        public async Task<IActionResult> Cities()
        {
            return Ok(await _cityService.GetAllAsync());
        }
    }
}
