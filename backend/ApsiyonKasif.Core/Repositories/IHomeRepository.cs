using ApsiyonKasif.Core.DTOs.RequestDto;
using ApsiyonKasif.Core.Entities;

namespace ApsiyonKasif.Core.Repositories
{
    public interface IHomeRepository : IGenericRepository<Home>
    {
        Task<List<OwnerHomesDto>> OwnerHomeList();
    }

}
