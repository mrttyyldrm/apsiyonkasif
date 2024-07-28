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
    public class HomeService : GenericService<Home>, IHomeService
    {
        private readonly IHomeRepository _homeRepository;
        public HomeService(IGenericRepository<Home> repository, IUnitOfWork unitOfWork, IHomeRepository homeRepository) : base(repository, unitOfWork)
        {
            _homeRepository = homeRepository;
        }

        public async Task<List<OwnerHomesDto>> OwnerHomeList()
        {
            return await _homeRepository.OwnerHomeList();
        }
    }
}
