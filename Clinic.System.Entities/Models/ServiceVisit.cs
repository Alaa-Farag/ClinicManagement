using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clinic.System.Entities.Models
{
    public class ServiceVisit : EntityBase
    {
      
        public int DoctorId { get; set; } 
        public int ServiceId { get; set; }
        public int VisitId { get; set; }
        public DateTime Appointment { get; set; }
        public Doctor Doctor { get; set; }
        public Service Service { get; set; }
        public Visit Visit { get; set; }
    }
}
