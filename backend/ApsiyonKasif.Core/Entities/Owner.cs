﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApsiyonKasif.Core.Entities
{
    public class Owner
    {
        public int Id { get; set; }
        public int HomeId { get; set; }

        [JsonIgnore]
        public Home Home { get; set; }
        public int AppUserId { get; set; }

        [JsonIgnore]
        public AppUser AppUser { get; set; }


        [JsonIgnore]
        public ICollection<Appointment> Appointments { get; set; }
    }
}
