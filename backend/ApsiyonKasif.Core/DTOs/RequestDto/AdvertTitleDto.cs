using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsiyonKasif.Core.DTOs.RequestDto
{
    public class AdvertTitleDto
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string CityName { get; set; }
        public string CountyName { get; set; }
    }
}
