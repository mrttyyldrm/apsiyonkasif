using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsiyonKasif.Core.DTOs.RequestDto
{
    public record ResultAdvertAppointmentDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string CityName { get; set; }
        public string CountyName { get; set; }
        public string ImageUrl { get; set; } 
        public List<ResultAppointmentDetailDto> AppointmentList { get; set; }
    }
}
