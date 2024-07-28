using ApsiyonKasif.Core.DTOs.RequestDto;
using ApsiyonKasif.Core.Entities;
using ApsiyonKasif.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ApsionKasif.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class AdvertController : ControllerBase
    {
        private readonly IAdvertService _advertService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AdvertController(IAdvertService advertService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _advertService = advertService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        [Route("AdvertDetailWithId")]
        public async Task<IActionResult> AdvertDetailWithId(int advertTypeId, int cityId, int countyId, int districtId)
        {
            return Ok(await _advertService.AdvertDetailWithId(advertTypeId, cityId, countyId, districtId));
        }

        [HttpGet]
        [Route("AdvertDetail")]
        public async Task<IActionResult> AdvertDetail(int advertId)
        {
            return Ok(await _advertService.GetAdvertDetails(advertId));
        }

        [HttpPost]
        [Route("CreateAdvert")]
        public async Task<IActionResult> CreateAdvert(CreateAdvertDto createAdvertDto)
        {
            await _advertService.CreateAdvert(createAdvertDto);
            return Ok("Added");
        }
    }
}
