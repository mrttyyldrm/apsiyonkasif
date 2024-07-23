﻿using ApsiyonKasif.Core.Entities;
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
    public class DistrictService : GenericService<District>, IDistrictService
    {
        public DistrictService(IGenericRepository<District> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
