using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsiyonKasif.Core.DTOs.RequestDto
{
    public record FeaturesDto
    {
        public string RoomCount { get; set; }
        public string NetArea { get; set; }
        public string AdvertTypeName { get; set; }
    }
}
