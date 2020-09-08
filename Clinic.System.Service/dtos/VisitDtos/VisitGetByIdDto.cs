using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.System.Service.dtos.VisitDtos
{
    public class VisitGetByIdDto
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public int PatientAge { get; set; }
        public string PatientPhone { get; set; }
        public DateTime VisitDate { get; set; }
    }
}
