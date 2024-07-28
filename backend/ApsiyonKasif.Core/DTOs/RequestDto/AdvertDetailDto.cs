using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsiyonKasif.Core.DTOs.RequestDto
{
    public record AdvertDetailDto
    {
        public AdvertTitleDto AdvertTitle { get; set; }
        public AdvertInfoDto Advert { get; set; }
        public LocationInfoDto Location { get; set; }
        public BillingInfoDto Billing { get; set; }
        public RentalHistoryDto History { get; set; }
        public OwnerContactInfoDto Owner { get; set; }
        public List<AppointmentInfoDto> Appointments { get; set; }
        public List<ServiceDto> Services { get; set; }
        public TourUrlDto TourUrl { get; set; }
        public List<string> Images { get; set; } 
    }
}
