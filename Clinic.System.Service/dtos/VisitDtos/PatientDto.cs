using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.System.Service.dtos.VisitDtos
{
    public class PatientDto
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int PatientAge { get; set; }
        public string PatientPhone { get; set; }
        public string PatientAddress { get; set; }
        public string PatientEmail { get; set; }
    }
}
