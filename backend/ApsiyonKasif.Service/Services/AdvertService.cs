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
    public class AdvertService : GenericService<Advert>, IAdvertService
    {
        private readonly IAdvertRepository _advertRepository;
        public AdvertService(IGenericRepository<Advert> repository, IUnitOfWork unitOfWork, IAdvertRepository advertRepository) : base(repository, unitOfWork)
        {
            _advertRepository = advertRepository;
        }

        public async Task<List<AdvertCartDto>> AdvertDetailWithId(int advertTypeId, int cityId, int countyId, int districtId)
        {
            return await _advertRepository.AdvertDetailWithId(advertTypeId, cityId, countyId, districtId);
        }

        public async Task<Advert> CreateAdvert(CreateAdvertDto create)
        {
            return await _advertRepository.CreateAdvert(create);
        }

        public async Task<AdvertDetailDto> GetAdvertDetails(int advertId)
        {
            return await _advertRepository.GetAdvertDetails(advertId);
        }
    }
}
