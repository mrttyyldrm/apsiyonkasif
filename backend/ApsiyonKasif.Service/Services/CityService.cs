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
    public class CityService : GenericService<City>, ICityService
    {
        private readonly ICityRepository _cityRepository;
        public CityService(IGenericRepository<City> repository, IUnitOfWork unitOfWork, ICityRepository cityRepository) : base(repository, unitOfWork)
        {
            _cityRepository = cityRepository;
        }

        public async Task<City> GetCityById(int cityId)
        {
            return await _cityRepository.GetCityById(cityId);
        }
    }
}
