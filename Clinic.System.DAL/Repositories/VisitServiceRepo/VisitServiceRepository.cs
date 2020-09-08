using Clinic.System.DAL.DbContainer;
using Clinic.System.DAL.Repositories.GenericRepo;
using Clinic.System.Entities.Models;
using Clinic.System.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.System.DAL.Repositories.VisitServiceRepo
{
    public class VisitServiceRepository : Repository<ServiceVisit>, IVisitServiceRepository
    {
        public VisitServiceRepository(ClinicContext db)
            :base(db)
        {

        }
    }
}
