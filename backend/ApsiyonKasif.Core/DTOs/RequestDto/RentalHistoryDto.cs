using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsiyonKasif.Core.DTOs.RequestDto
{
    public record RentalHistoryDto
    {
        public List<TenantDto> Tenants { get; set; }
    }
}
