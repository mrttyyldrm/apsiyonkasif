using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsiyonKasif.Core.DTOs.RequestDto
{
    public record OwnerHomesDto
    {
        public int HomeId { get; set; }
        public string Title { get; set; }
        public string CountyName { get; set; }
        public string CityName { get; set; }
        public FeaturesDto Features { get; set; }
        public string ImageUrl { get; set; }
    }
}
