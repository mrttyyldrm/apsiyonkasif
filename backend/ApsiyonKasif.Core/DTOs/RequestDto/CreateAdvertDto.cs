using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsiyonKasif.Core.DTOs.RequestDto
{
    public record CreateAdvertDto
    {
        public decimal Price { get; set; }
        public int AdvertTypeId { get; set; }
        public int HomeId { get; set; }
    }
}
