using Clinic.System.DAL.DbContainer;
using Clinic.System.DAL.Repositories.GenericRepo;
using Clinic.System.Entities.Models;
using Clinic.System.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.System.DAL.Repositories.ServiceRepo
{
   public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        public ServiceRepository(ClinicContext db)
            :base(db)
        {

        }
    }
}
