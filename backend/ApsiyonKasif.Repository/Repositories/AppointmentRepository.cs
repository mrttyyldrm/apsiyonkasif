using ApsiyonKasif.Core.DTOs.RequestDto;
using ApsiyonKasif.Core.Entities;
using ApsiyonKasif.Core.Repositories;
using ApsiyonKasif.Repository.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApsiyonKasif.Repository.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;
        public AppointmentRepository(AppDbContext context, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager) : base(context)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<List<ResultAdvertAppointmentDto>> AdvertWithAppointments()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier)!.Value;

            var adverts = await _context.Adverts
                .Include(x => x.Home)
                        .ThenInclude(x => x.HomeImages)
                .Include(x => x.Home)
                    .ThenInclude(x => x.Apartment)
                        .ThenInclude(ap => ap.District)
                            .ThenInclude(d => d.County)
                                .ThenInclude(c => c.City)
                .Where(x => x.Home.Owner.AppUserId == userId)
                .ToListAsync();

            var appointmentList = new List<ResultAdvertAppointmentDto>();

            foreach (var item in adverts)
            {
                var appointments = await _context.Appointments
                    .Where(a => a.AdvertId == item.Id && a.IsScheduled == true)
                    .Include(x => x.AppUser)
                    .ToListAsync();

                var result = new ResultAdvertAppointmentDto
                {
                    Id = item.Id,
                    Title = item.Title,
                    Price = item.Price,
                    CityName = item.Home.Apartment.District.County.City.Name,
                    CountyName = item.Home.Apartment.District.County.Name,
                    ImageUrl = item.Home.HomeImages.FirstOrDefault()!.Url,
                    AppointmentList = appointments.Select(appointment => new ResultAppointmentDetailDto
                    {
                        Id = appointment.Id,
                        Date = appointment.Date, 
                        FullName = appointment.AppUser.Name!,
                        Hours = appointment.Hours
                    }).ToList()
                };

                appointmentList.Add(result);
            }

            return appointmentList;
        }

        public async Task CreateAppointmentByHours(CreateAppointmentDto appointmentDto)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value;

            if (DateOnly.TryParse(appointmentDto.Date, out DateOnly parsedDate) && TimeOnly.TryParse(appointmentDto.Hour, out TimeOnly parsedTime))
            {
                TimeSpan timeSpan = parsedTime.ToTimeSpan();
                
                var appointment = await _context.Appointments
                    .FirstOrDefaultAsync(x => x.Date == parsedDate && x.Hours == timeSpan);

                if (appointment != null)
                {
                    if (!appointment.IsScheduled)
                    {
                        appointment.IsScheduled = true;
                        appointment.AppUserId = userId;
                        await _context.SaveChangesAsync();
                    }
                }
            }
        }

        public async Task<List<AppointmentListDto>> GetAppointmentsByDate(string date)
        {
            if (DateOnly.TryParse(date, out DateOnly parsedDate))
            {
                var appointments = await _context.Appointments
                    .Where(x => x.Date == parsedDate && x.IsScheduled == false)
                    .ToListAsync();

                return appointments.Select(x => new AppointmentListDto
                {
                    Text = x.Hours.ToString(@"hh\:mm"),
                    Value = x.Hours.ToString(@"hh\:mm")
                }).ToList();
            }

            return null;
        }
    }
}
