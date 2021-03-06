﻿using Clinic.System.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.System.Service.dtos.DoctorDtos
{
    public class DoctorGetAllDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public IEnumerable<Clinic.System.Entities.Models.Service> Services { get; set; }

    }
}
