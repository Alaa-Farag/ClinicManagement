using Clinic.System.Entities.Models;
using Clinic.System.Interface;
using Clinic.System.Service.dtos.VisitDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinic.System.Service.Services.VisitServices
{
   public class VisitSer: IVisitSer
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVisitRepository _visitRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IVisitServiceRepository _visitServiceRepository;

        public VisitSer(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _visitRepository = _unitOfWork.GetVisitRepo();
            _patientRepository = _unitOfWork.GetPatientRepo();
            _visitServiceRepository = _unitOfWork.GetVisitServiceRepo();
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

        public VisitCreateDto Create(VisitCreateDto visitDto)
        {
            var servicevisit = new ServiceVisit();

            var visit = new Visit();
            visit.VisitDate = DateTime.Now;

            if (visitDto.Patient.PatientId != 0)
            {

                var OldPatient = _patientRepository.GetById(visitDto.Patient.PatientId);
                if (OldPatient == null)
                {
                    throw new Exception($"Patient With Id :{visitDto.Patient.PatientId} is not Exsit");
                }
                visit.PatientId = visitDto.Patient.PatientId;
              
            }

            else
            {
                var newpatient = new Patient
                {
                    Address = visitDto.Patient.PatientAddress,
                    Name = visitDto.Patient.PatientName,
                    Age= visitDto.Patient.PatientAge,
                    Email= visitDto.Patient.PatientEmail,
                    Phone = visitDto.Patient.PatientPhone
                   
                };
                visit.Patient = newpatient;
              
            }

            

            return visitDto;

        }

        private Patient CreatePatient(VisitCreateDto visit)
        {
            var newpatient = new Patient();
            newpatient.Name = visit.Patient.PatientName;
            newpatient.Phone = visit.Patient.PatientPhone;
            newpatient.Email = visit.Patient.PatientEmail;
            newpatient.Address = visit.Patient.PatientAddress;
            newpatient.Age = visit.Patient.PatientAge;
            _patientRepository.Create(newpatient);

            return newpatient;
        }

        public bool Delete (int id)
        {
            _visitRepository.Delete(id);
            _unitOfWork.Complete();

            return true;
        }
    }
}
