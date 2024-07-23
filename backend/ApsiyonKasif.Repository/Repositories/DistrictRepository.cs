﻿using ApsiyonKasif.Core.Entities;
using ApsiyonKasif.Core.Repositories;
using ApsiyonKasif.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsiyonKasif.Repository.Repositories
{
    public class DistrictRepository : GenericRepository<District>, IDistrictRepository
    {
        public DistrictRepository(AppDbContext context) : base(context)
        {
        }
    }
}