﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.System.Service.dtos.ServiceDto
{
    public class ServiceGetByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
    }
}
