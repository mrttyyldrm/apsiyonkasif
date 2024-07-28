using ApsiyonKasif.Core.DTOs.RequestDto;
using ApsiyonKasif.Core.DTOs.ResponseDto;
using ApsiyonKasif.Core.Entities;
using ApsiyonKasif.Core.Repositories;
using ApsiyonKasif.Repository.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TenantDto = ApsiyonKasif.Core.DTOs.RequestDto.TenantDto;

namespace ApsiyonKasif.Repository.Repositories
{
    public class AdvertRepository : GenericRepository<Advert>, IAdvertRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;
        public AdvertRepository(AppDbContext context, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager) : base(context)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<List<AdvertCartDto>> AdvertDetailWithId(int advertTypeId, int cityId, int countyId, int districtId)
        {
            var adverts = await _context.Adverts
                .Include(x => x.AdvertType)
                .Include(x => x.Home)
                    .ThenInclude(x => x.HomeImages)
                .Include(x => x.Home)
                    .ThenInclude(x => x.RoomCount)
                .Include(x => x.Home)
                    .ThenInclude(x => x.Apartment)
                        .ThenInclude(x => x.BuildingComplex)
                .Include(x => x.Home)
                    .ThenInclude(x => x.Apartment)
                        .ThenInclude(x => x.District)
                            .ThenInclude(x => x.County)
                                .ThenInclude(x => x.City)
                .Where(x => x.AdvertTypeId == advertTypeId &&
                            x.Home.Apartment.DistrictId == districtId &&
                            x.Home.Apartment.District.CountyId == countyId &&
                            x.Home.Apartment.District.County.CityId == cityId)
                .ToListAsync();

            var resultList = new List<AdvertCartDto>();
            

            foreach (var item in adverts)
            {
                var titleName = item.Home.Apartment.District?.Name + " Mahallesi";
                var firstImageUrl = item.Home.HomeImages?.FirstOrDefault()?.Url;

                var netArea = _context.Homes
                .Select(p => p.NetArea)
                .FirstOrDefault();

                var result = new AdvertCartDto
                {
                    Id = item.Id,
                    Features = new FeaturesDto
                    {
                        AdvertTypeName = item.AdvertType.Name,
                        NetArea = netArea,
                        RoomCount = item.Home.RoomCount.Name,
                    },
                    CityName = item.Home.Apartment.District!.County.City.Name,
                    CountyName = item.Home.Apartment.District.County.Name,
                    Price = item.Price,
                    ImageUrl = firstImageUrl,
                    Title = $"{titleName} {item.Home.RoomCount.Name} Daire {item.AdvertType.Name}"

                };
                resultList.Add(result);
            }

            return resultList;
        }

        public async Task<Advert> CreateAdvert(CreateAdvertDto create)
        {
            var home = await _context.Homes
                .Include(h => h.RoomCount)
                .Include(h => h.Apartment)
                    .ThenInclude(ap => ap.District)
                        .ThenInclude(d => d.County)
                            .ThenInclude(c => c.City)
                .FirstOrDefaultAsync(h => h.Id == create.HomeId);


            var advertType = await _context.AdvertTypes
                .FindAsync(create.AdvertTypeId);

            var buildingComplexId = home.Apartment?.BuildingComplexId;
            var buildingComplexName = string.Empty;
            if (buildingComplexId != null)
            {
                var buildingComplex = await _context.BuildingComplexes
                    .FirstOrDefaultAsync(x => x.Id == buildingComplexId);
                buildingComplexName = buildingComplex?.Name ?? string.Empty;
            }

            var roomCount = home.RoomCount?.Name;
            var advertTypeName = advertType?.Name;

            var titleName = home.Apartment.BuildingComplex?.Name ?? home.Apartment.Name;

            var createAdvert = new Advert
            {
                AdvertTypeId = create.AdvertTypeId,
                Price = create.Price,
                CreatedDate = DateTime.Now,
                HomeId = create.HomeId,
                Title = $"{titleName} {home.Apartment.ConnectedBlock} {home.Floor}.Kat Daire {home.DoorNumber}"
            };

            await _context.Adverts.AddAsync(createAdvert);
            await _context.SaveChangesAsync();

            return createAdvert;
        }

        public async Task<AdvertDetailDto> GetAdvertDetails(int advertId)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier)!.Value;

            var advert = await _context.Adverts
                .Include(x => x.Appointments)
                .Include(x => x.AdvertType)
                .Include(x => x.Home)
                    .ThenInclude(x => x.Apartment)
                        .ThenInclude(x => x.BuildingComplex)
                            .ThenInclude(x => x.BuildingComplexServices)
                                .ThenInclude(x => x.Service)
                .Include(x => x.Home)
                    .ThenInclude(x => x.Apartment)
                        .ThenInclude(x => x.District)
                            .ThenInclude(x => x.County)
                                .ThenInclude(x => x.City)
                .Include(x => x.Home)
                    .ThenInclude(x => x.HomeImages)
                .Include(x => x.Home)
                    .ThenInclude(x => x.RoomCount)
                .Include(x => x.Home)
                    .ThenInclude(x => x.Invoices)
                        .ThenInclude(i => i.InvoiceType)
                .Include(x => x.Home)
                    .ThenInclude(x => x.Apartment)
                        .ThenInclude(x => x.HeatingType)
                .Include(x => x.Home)
                    .ThenInclude(x => x.Tenants)
                .Include(x => x.Home)
                    .ThenInclude(x => x.Owner)
                        .ThenInclude(x => x.AppUser)
                .FirstOrDefaultAsync(x => x.Id == advertId);

            var advertItem = await _context.Adverts
                .Include(x => x.Home)
                    .ThenInclude(x => x.Apartment)
                        .ThenInclude(x => x.BuildingComplex)
                .FirstOrDefaultAsync(x => x.Id == advertId);

            var netArea = advert.Home.NetArea;

            var titleName = advert.Home.Apartment.BuildingComplex?.Name ?? advert.Home.Apartment.Name;

            var advertTitle = new AdvertTitleDto
            {
                Title = titleName,
                Price = advertItem.Price,
                CityName = advertItem.Home.Apartment.District.County.City.Name,
                CountyName = advertItem.Home.Apartment.District.County.Name
            };

            var advertInfo = new AdvertInfoDto
            {
                AdvertNumber = advert.Id.ToString(),
                AdvertDate = advert.CreatedDate.ToString("yyyy-MM-dd"),
                NetArea = netArea,
                RoomCount = advert.Home.RoomCount?.Name,
                BuildingAge = advert.Home.Apartment?.Age ?? 0,  
                BathroomCount = advert.Home.BathromCount,
                AdvertType = advert.AdvertType?.Name, 
                Floor = advert.Home.Floor,
                NumberOfFloor = advert.Home.Apartment.NumberOfFloor,
                HasFurnished = advert.Home.HasFurnished,
                HeatingType = advert.Home.Apartment?.HeatingType?.Name, 
                IsInSite = string.IsNullOrEmpty(advert.Home.Apartment?.BuildingComplex?.Name)
                    ? null
                    : advert.Home.Apartment.BuildingComplex.Name
            };

            var location = new LocationInfoDto
            {
                Latitude = advert.Home.Latitude,
                Longitude = advert.Home.Longitude,
            };

            var billing = new BillingInfoDto
            {
                Invoices = advert.Home.Invoices?.Select(i => new InvoiceDto
                {
                    Amount = i.Amount,
                    InvoiceTypeName = i.InvoiceType?.Name,
                    Icon = i.Icon
                }).ToList() ?? new List<InvoiceDto>()
            };

            var rentalHistory = new RentalHistoryDto
            {
                Tenants = advert.Home.Tenants?.Select(t => new TenantDto
                {
                    StartDate = t.StartDate.ToString("yyyy-MM-dd"),
                    Price = t.Price,
                    Duration = t.Duration,
                }).ToList() ?? new List<TenantDto>()
            };

            var tourUrl = new TourUrlDto
            {
                Url = advertItem.TourUrl
            };

            var siteServices = advert.Home.Apartment.BuildingComplex?.BuildingComplexServices
            .Select(bcs => new ServiceDto
            {
                Name = bcs.Service.Name
            }).ToList() ?? new List<ServiceDto>();

            var ownerContact = new OwnerContactInfoDto
            {
                Name = advert.Home.Owner?.AppUser?.Name!,
                Number = advert.Home.Owner?.AppUser?.PhoneNumber!,
                Image = advert.Home.Owner?.AppUser?.ImageUrl!,
                IsOwner = advert.Home.Owner?.AppUserId == userId
            };

            var firstAppointment = advert.Appointments.FirstOrDefault();

            var appointments = advert.Appointments
            .GroupBy(appointment => appointment.Date)
            .Select(group => new AppointmentInfoDto
            {
                Text = group.Key.ToString("yyyy-MM-dd"),
                Value = group.Key.ToString("yyyy-MM-dd")
            })
            .ToList();


            var homeImages = advert.Home.HomeImages?.Select(img => img.Url).ToList() ?? new List<string>();
            var advertDetail = new AdvertDetailDto
            {
                AdvertTitle = advertTitle,
                Advert = advertInfo,
                Location = location,
                Billing = billing,
                History = rentalHistory,
                Owner = ownerContact,
                Images = homeImages,
                Services = siteServices,
                TourUrl = tourUrl,
                Appointments = appointments
            };

            return advertDetail;
        }
    }
}
