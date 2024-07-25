using ApsiyonKasif.Core.Entities;
using ApsiyonKasif.Core.Repositories;
using ApsiyonKasif.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsiyonKasif.Repository.Repositories
{
    public class CountyRepository : GenericRepository<County>, ICountyRepository
    {
        public CountyRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<County>> GetCountiesByCityIdAsync(int cityId)
        {
            return await _context.Counties.Where(x => x.City.Id == cityId).ToListAsync();
        }
    }
}
