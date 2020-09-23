using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinic.System.Service.dtos.VisitDtos;
using Clinic.System.Service.Services.DoctorServices;
using Clinic.System.Service.Services.DoctorServiceServices;
using Clinic.System.Service.Services.PatientServices;
using Clinic.System.Service.Services.ServiceServices;
using Clinic.System.Service.Services.VisitServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Clinic.System.UI.Controllers
{
    public class VisitController : Controller
    {
        private readonly IVisitSer _visitService;
        private readonly IDoctorSer _doctor;
        private readonly IDoctorServiceSer _doctorService;
        private readonly IPatientSer _patientSer;
        private readonly IServiceSer _serviceSer;

        public VisitController( IVisitSer visitService,
                                IDoctorSer doctor,
                                IDoctorServiceSer doctorService ,
                                IPatientSer patientSer ,
                                IServiceSer serviceSer )
        {
            _visitService = visitService;
            _doctor = doctor;
            _doctorService = doctorService;
            _patientSer = patientSer;
            _serviceSer = serviceSer;
        }
        public IActionResult Index()
        {
            ViewBag.ServiceId = new SelectList(_serviceSer.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Index(VisitCreateDto visitCreateDto)
        {
            _visitService.Create(visitCreateDto);
            return View("/Home/Index");
        }

        // -------- Ajax Calls ----------

        public IActionResult SearchByPhone (string Phone)
        {
            var patient = _patientSer.GetByPhone(Phone);

            return Json(patient);
        }

        public IActionResult GetDoctorsByServiceId (int id )
        {
           var doctors=  _doctor.GetDoctorsByServiceId(id);

            return Json(doctors);
        }

        [HttpPost]
        public JsonResult SaveVisit (PatientDto patient)//, List<ServiceDto> services)
        {
             //var res=  _visitService.Create(visit);
            
            return Json("");
        }


    }
}
