using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsiyonKasif.Core.DTOs.RequestDto
{
    public record CreateAppointmentDto
    {
        public string Date { get; set; }
        public string Hour { get; set; }
    }
}
