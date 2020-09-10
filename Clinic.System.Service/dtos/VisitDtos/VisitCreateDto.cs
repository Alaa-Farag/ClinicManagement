using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.System.Service.dtos.VisitDtos
{
    public class VisitCreateDto
    {
        public PatientDto Patient { get; set; }
        public DateTime VisitDate { get; set; }
        public List<ServiceDto> MyProperty { get; set; }

    }
}
