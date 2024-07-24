using ApsiyonKasif.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApsionKasif.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictService _districtService;

        public DistrictController(IDistrictService districtService)
        {
            _districtService = districtService;
        }

        [HttpGet]
        [Route("GetDistrictDetail")]
        public async Task<IActionResult> GetDistrictDetail([FromQuery]int districtId)
        {
            return Ok(await _districtService.GetDistrictDetailsAsync(districtId));
        }
    }
}
