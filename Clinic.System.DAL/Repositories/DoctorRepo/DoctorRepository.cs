using Clinic.System.DAL.DbContainer;
using Clinic.System.DAL.Repositories.GenericRepo;
using Clinic.System.Entities.Models;
using Clinic.System.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinic.System.DAL.Repositories.DoctorRepo
{
   public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        private readonly ClinicContext db;

        public DoctorRepository(ClinicContext db)
            :base(db)
        {
            this.db = db;
        }

        public override List<Doctor> GetAll()
        {
            var result= db.Doctors.Include(a=>a.DoctorServices)
                        .ThenInclude(s => s.Service)
                        .ToList();
            return result;
        }

        public override Doctor GetById(int id)
        {
            var result = db.Doctors.Include(a => a.DoctorServices)
                         .ThenInclude(s => s.Service)
                         .FirstOrDefault(a => a.Id == id);
            return result;
        }

        public List<Doctor> GetDoctorsByServiceId(int serviceId)
        {
            //var result =  db.Doctors.Include(a => a.DoctorServices)
            //     .ThenInclude(a => a.Service).Where(a => a.DoctorServices
            //     .Any(s => s.ServiceId == serviceId)).Select(a=> new Doctor {Id = a.Id , Name=a.Name })
            //     .ToList();

            var result = db.Services.Where(a => a.Id == serviceId)
                            .SelectMany(a=> a.DoctorServices)
                            .Select(a=>a.Doctor).Select(a=> new Doctor {Id=a.Id,Name=a.Name }).ToList();
            return result;
        }
    }
}
