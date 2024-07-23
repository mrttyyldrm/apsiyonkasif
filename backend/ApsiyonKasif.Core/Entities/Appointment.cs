using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApsiyonKasif.Core.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }


        [JsonIgnore]
        public AppUser AppUser { get; set; }

        public int OwnerId { get; set; }

        [JsonIgnore]
        public Owner Owner { get; set; }
    }
}
