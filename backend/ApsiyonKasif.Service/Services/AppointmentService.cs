using ApsiyonKasif.Core.DTOs.RequestDto;
using ApsiyonKasif.Core.Entities;
using ApsiyonKasif.Core.Repositories;
using ApsiyonKasif.Core.Services;
using ApsiyonKasif.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsiyonKasif.Service.Services
{
    public class AppointmentService : GenericService<Appointment>, IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        public AppointmentService(IGenericRepository<Appointment> repository, IUnitOfWork unitOfWork, IAppointmentRepository appointmentRepository) : base(repository, unitOfWork)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<List<ResultAdvertAppointmentDto>> AdvertWithAppointments()
        {
            return await _appointmentRepository.AdvertWithAppointments();
        }

        public async Task CreateAppointmentByHours(CreateAppointmentDto appointmentDto)
        {
            await _appointmentRepository.CreateAppointmentByHours(appointmentDto);
        }

        public async Task<List<AppointmentListDto>> GetAppointmentsByDate(string date)
        {
            return await _appointmentRepository.GetAppointmentsByDate(date);
        }
    }
}
