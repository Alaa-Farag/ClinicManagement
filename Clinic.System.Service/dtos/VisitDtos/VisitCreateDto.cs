using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.System.Service.dtos.VisitDtos
{
    public class VisitCreateDto
    {
        public DateTime VisitDate { get; set; }
        public int PatientId { get; set; }
    }
}
