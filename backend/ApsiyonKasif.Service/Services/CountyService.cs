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
    public class CountyService : GenericService<County>, ICountyService
    {
        private readonly ICountyRepository _countyRepository;
        public CountyService(IGenericRepository<County> repository, IUnitOfWork unitOfWork, ICountyRepository countyRepository) : base(repository, unitOfWork)
        {
            _countyRepository = countyRepository;
        }

        public async Task<List<County>> GetCountiesByCityId(int cityId)
        {
            return await _countyRepository.GetCountiesByCityId(cityId);
        }
    }
}
