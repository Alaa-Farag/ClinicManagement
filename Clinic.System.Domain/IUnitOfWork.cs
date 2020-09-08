using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.System.Interface
{
    public interface IUnitOfWork
    {
        IDoctorRepository GetDoctorRepo();
        IDoctorServiceRepository GetDoctorServiceRepo();
        IPatientRepository GetPatientRepo();
        IServiceRepository GetServiceRepo();
        IVisitRepository GetVisitRepo();
        IVisitServiceRepository GetVisitServiceRepo();
        int Complete();
    }
}
