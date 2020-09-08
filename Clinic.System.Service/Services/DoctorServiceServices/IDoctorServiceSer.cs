using Clinic.System.Service.dtos.DoctorServiceDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.System.Service.Services.DoctorServiceServices
{
    public interface IDoctorServiceSer
    {
        List<DoctorServiceGetAllDto> GetAll();
        DoctorServiceGetByIdDto GetById(int id);
        DoctorServiceCreateDto Create(DoctorServiceCreateDto doctorService);
        bool Edit(DoctorServiceEditDto doctorService);
        bool Delete(int id);
    }
}
