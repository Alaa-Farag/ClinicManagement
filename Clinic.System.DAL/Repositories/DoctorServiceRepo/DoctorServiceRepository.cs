using Clinic.System.DAL.DbContainer;
using Clinic.System.DAL.Repositories.GenericRepo;
using Clinic.System.Entities.Models;
using Clinic.System.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinic.System.DAL.Repositories.DoctorServiceRepo
{
    public class DoctorServiceRepository : Repository<DoctorService>, IDoctorServiceRepository
    {
        private readonly ClinicContext _db;

        public DoctorServiceRepository(ClinicContext db)
            :base(db)
        {
            _db = db;
        }

        public override List<DoctorService> GetAll()
        {
           var result= _db.DoctorServices.Include(a => a.Doctor).Include(a => a.Service).ToList();
            return result;
        }

        public override DoctorService GetById(int id)
        {
            var result = _db.DoctorServices.Include(a => a.Doctor)
                        .Include(a => a.Service)
                        .FirstOrDefault(a => a.Id == id);

            return result;
        }
    }
}
