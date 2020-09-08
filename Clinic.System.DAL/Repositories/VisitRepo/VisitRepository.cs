using Clinic.System.DAL.DbContainer;
using Clinic.System.DAL.Repositories.GenericRepo;
using Clinic.System.Entities.Models;
using Clinic.System.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinic.System.DAL.Repositories.VisitRepo
{
   public class VisitRepository : Repository<Visit>, IVisitRepository
    {
        private readonly ClinicContext _db;

        public VisitRepository(ClinicContext db)
            :base(db)
        {
            _db = db;
        }

        public override List<Visit> GetAll()
        {
            var result = _db.Visits.Include(a => a.Patient).ToList();

            return result;
        }

        public override Visit GetById(int id)
        {
           var result=  _db.Visits.Include(a => a.Patient).FirstOrDefault(a => a.Id == id);

            return result;
        }
    }
}
