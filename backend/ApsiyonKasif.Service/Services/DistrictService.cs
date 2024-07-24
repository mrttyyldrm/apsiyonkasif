using ApsiyonKasif.Core.Entities;
using ApsiyonKasif.Core.Repositories;
using ApsiyonKasif.Core.Services;
using ApsiyonKasif.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsiyonKasif.Service.Services
{
    public class DistrictService : GenericService<District>, IDistrictService
    {
        IDistrictRepository _districtRepository;
        public DistrictService(IGenericRepository<District> repository, IUnitOfWork unitOfWork, IDistrictRepository districtRepository) : base(repository, unitOfWork)
        {
            this._districtRepository = districtRepository;
        }

        public Task<District> GetDistrictDetailsAsync(int districtId)
        {
            return _districtRepository.GetDistrictDetailsAsync(districtId);
        }
    }
}
