using Clinic.System.Service.dtos.DoctorDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.System.Service.Services.DoctorServices
{
    public interface IDoctorSer
    {
        List<DoctorGetAllDto> GetAll();
        DoctorGetByIdDto GetById(int id);
        DoctorCreateDto Create(DoctorCreateDto doctor);
        bool Edit(DoctorEditDto doctor);
        bool Delete(int id);
    }
}
