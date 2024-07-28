using ApsiyonKasif.Core.DTOs.RequestDto;
using ApsiyonKasif.Core.Entities;
using ApsiyonKasif.Core.Repositories;
using ApsiyonKasif.Repository.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApsiyonKasif.Repository.Repositories
{
    public class HomeRepository : GenericRepository<Home>, IHomeRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HomeRepository(AppDbContext context, IHttpContextAccessor httpContextAccessor) : base(context)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<OwnerHomesDto>> OwnerHomeList()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value;

            var owner = await _context.Homes
                .Where(x => x.Owner.AppUserId == userId)
                .Select(x => x.Owner) 
                .FirstOrDefaultAsync();
                
            if (owner == null)
            {
                return new List<OwnerHomesDto>();
            }

            var homes = await _context.Homes
                .Include(x => x.Owner)
                .Include(x=>x.HomeImages)
                .Include(x => x.RoomCount)
                .Include(x => x.Apartment)
                    .ThenInclude(x => x.BuildingComplex)
                .Include(x => x.Apartment)
                    .ThenInclude(x => x.District)
                        .ThenInclude(x => x.County)
                            .ThenInclude(x => x.City)
                .Where(x => x.Owner.AppUserId == userId && !_context.Adverts.Any(a => a.HomeId == x.Id))
                .ToListAsync();

            var resultList = new List<OwnerHomesDto>();

            foreach (var item in homes)
            {
                var titleName = item.Apartment.BuildingComplex?.Name ?? item.Apartment.Name;
                var firstImageUrl = item.HomeImages?.FirstOrDefault()?.Url;

                var result = new OwnerHomesDto
                {
                    HomeId = item.Id,
                    Features = new FeaturesDto
                    {
                        NetArea = item.NetArea,
                        RoomCount = item.RoomCount.Name!
                    },
                    CityName = item.Apartment.District.County.City.Name,
                    CountyName = item.Apartment.District.County.Name,
                    ImageUrl = firstImageUrl!,
                    Title = $"{titleName} {item.Apartment.ConnectedBlock} {item.Floor}.Kat Daire {item.DoorNumber}"
                };

                resultList.Add(result);
            }

            return resultList;
        }
    }
}
