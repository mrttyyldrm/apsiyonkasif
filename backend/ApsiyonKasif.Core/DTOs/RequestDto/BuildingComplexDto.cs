using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsiyonKasif.Core.DTOs.RequestDto
{
    public record BuildingComplexDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ServiceDto> Services { get; set; } // Siteye ait hizmetler
    }
}
