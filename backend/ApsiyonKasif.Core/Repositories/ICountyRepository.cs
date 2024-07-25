using ApsiyonKasif.Core.Entities;

namespace ApsiyonKasif.Core.Repositories
{
    public interface ICountyRepository : IGenericRepository<County>
    {
        Task<List<County>> GetCountiesByCityIdAsync(int countyId);
    }

}
