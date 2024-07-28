using ApsiyonKasif.Core.Entities;

namespace ApsiyonKasif.Core.Services
{
    public interface IDistrictService : IGenericService<District>
    {
        Task<List<District>> GetDistrictsByCountId(int countyId);
        Task<District> GetDistrictDetailsAsync(int districtId);
    }
}
