using ApsiyonKasif.Core.DTOs.RequestDto;
using ApsiyonKasif.Core.Entities;

namespace ApsiyonKasif.Core.Services
{
    public interface IHomeService : IGenericService<Home>
    {
        Task<List<OwnerHomesDto>> OwnerHomeList();
    }
}
