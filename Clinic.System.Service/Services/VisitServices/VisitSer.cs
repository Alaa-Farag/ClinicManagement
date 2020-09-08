using Clinic.System.Interface;
using Clinic.System.Service.dtos.VisitDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinic.System.Service.Services.VisitServices
{
   public class VisitSer
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVisitRepository _visitRepository;
        private readonly IPatientRepository _patientRepository;

        public VisitSer(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _visitRepository = _unitOfWork.GetVisitRepo();
            _patientRepository = _unitOfWork.GetPatientRepo();
        }

        public List<VisitGetAllDto> GetAll ()
        {
            var result = _visitRepository.GetAll().Select(a => new VisitGetAllDto { 
                        Id= a.Id,
                        PatientName= a.Patient.Name,
                        PatientAge=a.Patient.Age,
                        PatientPhone=a.Patient.Phone,
                        VisitDate=a.VisitDate
            });

            return result.ToList();
        }

        public VisitGetByIdDto GetById(int id)
        {
            var result = _visitRepository.GetById(id);
            var visit = new VisitGetByIdDto();
            visit.Id = result.Id;
            visit.PatientName = result.Patient.Name;
            visit.PatientAge = result.Patient.Age;
            visit.PatientPhone = result.Patient.Phone;
            visit.VisitDate = result.VisitDate;

            return visit; 

        }

        //public VisitCreateDto Create (VisitCreateDto visit)
        //{

        //}
    }
}
