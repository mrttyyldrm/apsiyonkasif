using ApsiyonKasif.Core.DTOs.ResponseDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApsiyonKasif.Core.Entities
{
    public class Appointment
    {
        public int Id { get; set; }

        public DateOnly Date { get; set; }


        [JsonIgnore]
        public TimeSpan Hours { get; set; }
        public bool IsScheduled { get; set; }

        public string? AppUserId { get; set; }

        //[JsonIgnore]
        public AppUser AppUser { get; set; }
        
        public int AdvertId { get; set; }

        [JsonIgnore]
        public Advert Advert { get; set; }
    }
}
