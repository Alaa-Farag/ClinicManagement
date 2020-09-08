using Clinic.System.DAL.DbContainer;
using Clinic.System.DAL.Repositories.GenericRepo;
using Clinic.System.Entities.Models;
using Clinic.System.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.System.DAL.Repositories.PatientRepo
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(ClinicContext db)
            :base(db)
        {

        }
    }
}
