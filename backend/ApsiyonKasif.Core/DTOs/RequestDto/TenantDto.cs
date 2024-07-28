using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsiyonKasif.Core.DTOs.RequestDto
{
    public record TenantDto
    {
        public decimal Price { get; set; }
        public string StartDate { get; set; }
        public int Duration { get; set; } 
    }
}
