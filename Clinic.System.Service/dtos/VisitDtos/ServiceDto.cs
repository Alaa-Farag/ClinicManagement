using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.System.Service.dtos.VisitDtos
{
   public class ServiceDto
    {
        public int DoctorId { get; set; }
        public int ServiceId { get; set; }
        public int VisitId { get; set; }
        public DateTime Appointment { get; set; }
    }
}
