using Clinic.System.DAL.DbContainer;
using Clinic.System.DAL.Repositories.GenericRepo;
using Clinic.System.Entities.Models;
using Clinic.System.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinic.System.DAL.Repositories.PatientRepo
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        private readonly ClinicContext _db;

        public PatientRepository(ClinicContext db)
            :base(db)
        {
           _db = db;
        }

        public Patient GetByPhone(string phone)
        {
           var patient =  _db.Patients.Where(a => a.Phone == phone).SingleOrDefault();

            return patient;
        }

    }
}
