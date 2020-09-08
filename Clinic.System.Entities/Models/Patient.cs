using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.System.Entities.Models
{
    public class Patient: EntityBase
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
