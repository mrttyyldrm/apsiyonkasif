using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApsiyonKasif.Core.DTOs.RequestDto
{
    public record ResultAppointmentDetailDto
    {
        public int? Id { get; set; }
        public DateOnly Date { get; set; }
        public TimeSpan Hours { get; set; }
        public string FullName { get; set; }
    }
}
