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

            visit.Create(new Service.dtos.VisitDtos.VisitCreateDto { Patient = new Service.dtos.VisitDtos.PatientDto { PatientName = "Allaa", PatientId=4 }, VisitDate = DateTime.Now });
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
