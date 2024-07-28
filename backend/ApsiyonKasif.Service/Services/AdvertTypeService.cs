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
    public class AdvertTypeService : GenericService<AdvertType>, IAdvertTypeService
    {
        public AdvertTypeService(IGenericRepository<AdvertType> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
