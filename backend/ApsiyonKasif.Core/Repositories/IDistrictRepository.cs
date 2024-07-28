using ApsiyonKasif.Core.Entities;

namespace ApsiyonKasif.Core.Repositories
{
    public interface IDistrictRepository : IGenericRepository<District>
    {
        Task<List<District>> GetDistrictsByCountId(int countyId);
        Task<District> GetDistrictDetailsAsync(int districtId);
    }
}
