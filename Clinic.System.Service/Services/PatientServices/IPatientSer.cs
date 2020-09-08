using Clinic.System.Entities.Models;
using Clinic.System.Service.dtos.PatientDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.System.Service.Services.PatientServices
{
    public interface IPatientSer
    {
        List<PatientGetAlldto> GetAll();
        PatientGetByIddto GetbyId(int id);
        PatientCreatedto Create(PatientCreatedto patient);
        bool Edit(PatientEditdto patient);
        bool Delete(int id);
    }
}
