using ApsiyonKasif.Core.DTOs.RequestDto;
using ApsiyonKasif.Core.Entities;

namespace ApsiyonKasif.Core.Services
{
    public interface IAppointmentService : IGenericService<Appointment>
    {
        Task<List<AppointmentListDto>> GetAppointmentsByDate(string date);
        Task CreateAppointmentByHours(CreateAppointmentDto appointmentDto);
        Task<List<ResultAdvertAppointmentDto>> AdvertWithAppointments();
    }
}
