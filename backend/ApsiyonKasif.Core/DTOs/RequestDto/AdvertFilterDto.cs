using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsiyonKasif.Core.DTOs.RequestDto
{
    public record AdvertFilterDto(
        decimal? MaxPrice,
        decimal? MinPrice,
        int? MinApartmentAge,
        int? MaxApartmentAge,
        decimal? Dues,
        int? RoomCountId,
        int? Floor,
        decimal? MinNetArea,
        decimal? MaxNetArea,
        bool? HasFurnished,
        int? HeatingTypeId
        );
}
