using ApsiyonKasif.Core.DTOs.RequestDto;
using ApsiyonKasif.Core.Entities;
using ApsiyonKasif.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApsionKasif.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdvertController : ControllerBase
    {
        private readonly IAdvertService _advertService;
        private readonly IMapper _mapper;
        public AdvertController(IAdvertService advertService, IMapper mapper)
        {
            _advertService = advertService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Advert(CreateAdvertDto advertDto)
        {
            var advert = _mapper.Map<Advert>(advertDto);
            await _advertService.AddAsync(advert);
            return Ok("Added");
        }

        [HttpGet]
        public async Task<IActionResult> AdvertFiler([FromQuery] AdvertFilterDto filter)
        {
            return Ok(await _advertService.AdvertFilter(filter));
        }
    }
}
