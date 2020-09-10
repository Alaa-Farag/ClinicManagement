using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Clinic.System.UI.Models;
using Clinic.System.Interface;
using Clinic.System.Service.Services.VisitServices;
using Clinic.System.DAL.UnitOfWorks;
using Clinic.System.Service.dtos.VisitDtos;

namespace Clinic.System.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork uow;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork uow)
        {
            _logger = logger;
            this.uow = uow;
        }

        public IActionResult Index()
        {
            var visit = new VisitSer(this.uow);

            var input = new VisitCreateDto
            {
                Patient = new PatientDto { PatientName = "new Allaa" ,PatientId=4 },
                VisitDate = DateTime.Now,
                Services = new List<ServiceDto> { new ServiceDto { DoctorId = 2, ServiceId = 1,Appointment=DateTime.Now.AddDays(1) } , new ServiceDto { DoctorId = 1, ServiceId = 2, Appointment = DateTime.Now.AddDays(2) }, new ServiceDto { DoctorId = 2, ServiceId = 3, Appointment = DateTime.Now.AddDays(3) } }
            };

            visit.Create(input);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
