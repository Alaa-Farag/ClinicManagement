using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.System.Entities.Models
{
   public class Visit: EntityBase
    {
        public DateTime VisitDate { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
