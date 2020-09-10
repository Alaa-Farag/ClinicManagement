using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinic.System.DAL.DbContainer;
using Clinic.System.DAL.Repositories.DoctorRepo;
using Clinic.System.DAL.Repositories.DoctorServiceRepo;
using Clinic.System.DAL.Repositories.GenericRepo;
using Clinic.System.DAL.Repositories.PatientRepo;
using Clinic.System.DAL.Repositories.ServiceRepo;
using Clinic.System.DAL.Repositories.VisitRepo;
using Clinic.System.DAL.Repositories.VisitServiceRepo;
using Clinic.System.DAL.UnitOfWorks;
using Clinic.System.Interface;
using Clinic.System.Service.Services.DoctorServices;
using Clinic.System.Service.Services.DoctorServiceServices;
using Clinic.System.Service.Services.PatientServices;
using Clinic.System.Service.Services.ServiceServices;
using Clinic.System.Service.Services.VisitServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Clinic.System.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<ClinicContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IDoctorServiceRepository, DoctorServiceRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IVisitRepository, VisitRepository>();
            services.AddScoped<IVisitServiceRepository, VisitServiceRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPatientSer, PatientSer>();
            services.AddScoped<IDoctorSer, DoctorSer>();
            services.AddScoped<IServiceSer, ServiceSer>();
            services.AddScoped<IDoctorServiceSer, DoctorServiceSer>();
            services.AddScoped<IVisitSer, VisitSer>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
