using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.System.Service.dtos.DoctorServiceDtos
{
   public  class DoctorServiceGetByIdDto
    {
        public int Id { get; set; }
        public string DoctorName { get; set; }
        public string DoctorPhone { get; set; }
        public string ServiceName { get; set; }
        public float ServicePrice { get; set; }

    }
}
