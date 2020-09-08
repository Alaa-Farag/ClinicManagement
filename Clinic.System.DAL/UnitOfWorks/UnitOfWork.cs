
using Clinic.System.DAL.DbContainer;
using Clinic.System.DAL.Repositories.DoctorRepo;
using Clinic.System.DAL.Repositories.DoctorServiceRepo;
using Clinic.System.DAL.Repositories.PatientRepo;
using Clinic.System.DAL.Repositories.ServiceRepo;
using Clinic.System.DAL.Repositories.VisitRepo;
using Clinic.System.DAL.Repositories.VisitServiceRepo;
using Clinic.System.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.System.DAL.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ClinicContext _db;
        private readonly IServiceProvider _serviceProvider;

        public UnitOfWork(ClinicContext db ,IServiceProvider serviceProvider)
        {
            _db = db;
            _serviceProvider = serviceProvider;
        }
        public IDoctorRepository GetDoctorRepo()
        {
            var DoctorRepo = _serviceProvider.GetService<IDoctorRepository>();

            return DoctorRepo;
        }
        public IDoctorServiceRepository GetDoctorServiceRepo()
        {
            var DoctorServiceRepo = _serviceProvider.GetService<IDoctorServiceRepository>();

            return DoctorServiceRepo;
        }
        public IPatientRepository GetPatientRepo()
        {
            var PatientRepo = _serviceProvider.GetService<IPatientRepository>();

            return PatientRepo;
        }

        public IServiceRepository GetServiceRepo()
        {
            var ServiceRepo = _serviceProvider.GetService<IServiceRepository>();

            return ServiceRepo;
        }

        public IVisitRepository GetVisitRepo()
        {
            var VisitRepo = _serviceProvider.GetService<IVisitRepository>();

            return VisitRepo;
        }

        public IVisitServiceRepository GetVisitServiceRepo()
        {
            var VisitServiceRepo = _serviceProvider.GetService<IVisitServiceRepository>();

            return VisitServiceRepo;
        }


        public int Complete()
        {
            return _db.SaveChanges();
        }
    }
}
