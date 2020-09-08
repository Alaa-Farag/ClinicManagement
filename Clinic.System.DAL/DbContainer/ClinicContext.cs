using Clinic.System.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.System.DAL.DbContainer
{
    public class ClinicContext : DbContext
    {
        public ClinicContext(DbContextOptions<ClinicContext> options)
            :base(options)
        {

        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorService> DoctorServices { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceVisit> ServiceVisits { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServiceVisit>()
            .HasIndex(o => new { o.DoctorId, o.ServiceId, o.VisitId }).IsUnique();
        }
        public DbSet<Visit> Visits { get; set; }
    }
}
