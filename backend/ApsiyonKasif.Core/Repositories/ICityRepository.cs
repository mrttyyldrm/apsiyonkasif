﻿using ApsiyonKasif.Core.Entities;

namespace ApsiyonKasif.Core.Repositories
{
    public interface ICityRepository : IGenericRepository<City>
    {
        Task<City> GetCityById(int cityId);
    }

}
