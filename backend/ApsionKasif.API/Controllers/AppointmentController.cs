using ApsiyonKasif.Core.DTOs.RequestDto;
using ApsiyonKasif.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApsionKasif.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        [Route("GetAppointmentsByDate")]
        public async Task<IActionResult> GetAppointmentsByDate(string date)
        {
            return Ok(await _appointmentService.GetAppointmentsByDate(date));
        }

        [HttpPost]
        [Route("CreateAppointmentByHours")]
        public async Task<IActionResult> CreateAppointmentByHours(CreateAppointmentDto appointmentDto)
        {
            await _appointmentService.CreateAppointmentByHours(appointmentDto);
            return Ok();
        }

        [HttpGet]
        [Route("AdvertWithAppointments")]
        public async Task<IActionResult> AdvertWithAppointments()
        {
            return Ok(await _appointmentService.AdvertWithAppointments());
        }
    }
}
