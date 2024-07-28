using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApsiyonKasif.Core.Entities
{
    public class BuildingComplexService
    {
        public int Id { get; set; }
        public int BuildingComplexId { get; set; }

        [JsonIgnore]
        public BuildingComplex BuildingComplex { get; set; }

        public int ServiceId { get; set; }

        [JsonIgnore]
        public Service Service { get; set; }
    }
}
