﻿using ApsiyonKasif.Core.Entities;

namespace ApsiyonKasif.Core.Services
{
    public interface IDistrictService : IGenericService<District>
    {
        Task<List<District>> GetDistrictsByCountyIdAsync(int countyId);

    }
}
