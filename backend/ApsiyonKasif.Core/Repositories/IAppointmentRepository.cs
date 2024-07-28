using ApsiyonKasif.Core.DTOs.RequestDto;
using ApsiyonKasif.Core.Entities;

namespace ApsiyonKasif.Core.Repositories
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {
        Task<List<AppointmentListDto>> GetAppointmentsByDate(string date);
        Task CreateAppointmentByHours(CreateAppointmentDto appointmentDto);
        Task<List<ResultAdvertAppointmentDto>> AdvertWithAppointments();
    }
}
