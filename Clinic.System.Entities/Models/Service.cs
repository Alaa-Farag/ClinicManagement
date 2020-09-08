using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.System.Entities.Models
{
   public class Service: EntityBase
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public ICollection<DoctorService> DoctorServices { get; set; }
    }
}
