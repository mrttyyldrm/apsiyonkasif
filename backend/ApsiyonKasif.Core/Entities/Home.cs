using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApsiyonKasif.Core.Entities
{
    public class Home
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string DoorNumber { get; set; }
        public string GrossArea { get; set; }
        public string NetArea { get; set; }
        public string Floor { get; set; }
        public string Direction { get; set; }
        public bool HasBalcony { get; set; }
        public bool HasFurnished { get; set; }
        public int BathromCount { get; set; }

        [Column(TypeName = "decimal(8,6)")]
        public decimal Longitude { get; set; }

        [Column(TypeName = "decimal(8,6)")]
        public decimal Latitude { get; set; }

        public int ApartmentId { get; set; }

        [JsonIgnore]
        public Apartment Apartment { get; set; }

        public int RoomCountId { get; set; }

        [JsonIgnore]
        public RoomCount RoomCount { get; set; }

        [JsonIgnore]
        public Advert Advert { get; set; }

        public ICollection<Invoice> Invoices { get; set; }

        [JsonIgnore]
        public Owner Owner { get; set; }

        [JsonIgnore]
        public ICollection<Tenant> Tenants { get; set; }

        [JsonIgnore]
        public ICollection<HomeImage> HomeImages { get; set; }
    }
}
