using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.System.Entities.Models
{
    public class Doctor: EntityBase
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public ICollection<DoctorService> DoctorServices { get; set; }
    }
}
