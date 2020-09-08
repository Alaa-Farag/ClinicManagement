using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.System.Entities.Models
{
   public class DoctorService : EntityBase
    {
        public int DoctorId { get; set; }
        public int ServiceId { get; set; }
        public Doctor Doctor { get; set; }
        public Service Service { get; set; }
    }
}
