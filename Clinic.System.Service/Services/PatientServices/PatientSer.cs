using Clinic.System.Entities.Models;
using Clinic.System.Interface;
using Clinic.System.Service.dtos.PatientDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinic.System.Service.Services.PatientServices
{
    public class PatientSer : IPatientSer
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPatientRepository _patientRepository;

        public PatientSer(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _patientRepository = _unitOfWork.GetPatientRepo();

        }

        public List<PatientGetAlldto> GetAll()
        {
            var res= _patientRepository.GetAll().Select(a=> new PatientGetAlldto {
                    Id=a.Id,
                    Address=a.Address,
                    Age=a.Age,
                    Email=a.Email,
                    Phone=a.Phone,
                    Name=a.Name
            }).ToList();

            return res;
        }

        public PatientGetByIddto GetbyId(int id)
        {
            var res = new PatientGetByIddto();
            var patient=_patientRepository.GetById(id);
            res.Id = patient.Id;
            res.Name = patient.Name;
            res.Address = patient.Address;
            res.Age = patient.Age;
            res.Email = patient.Email;
            res.Phone = patient.Phone;
            return res;

        }

        public PatientGetByPhoneDto GetByPhone (string phone)
        {
            var res = new PatientGetByPhoneDto();
            var patient = _patientRepository.GetByPhone(phone);
            res.Id = patient.Id;
            res.Name = patient.Name;
            res.Address = patient.Address;
            res.Age = patient.Age;
            res.Email = patient.Email;
            res.Phone = patient.Phone;
            return res;
        }

        public PatientCreatedto Create(PatientCreatedto patient)
        {
            var res = new Patient();
            res.Name = patient.Name;
            res.Address = patient.Address;
            res.Age = patient.Age;
            res.Email = patient.Email;
            res.Phone = patient.Phone;

            _patientRepository.Create(res);

            _unitOfWork.Complete();

            return patient;
        }

        public bool Edit(PatientEditdto patient)
        {
            var res = new Patient();
            res.Id = patient.Id;
            res.Name = patient.Name;
            res.Address = patient.Address;
            res.Age = patient.Age;
            res.Email = patient.Email;
            res.Phone = patient.Phone;

            _patientRepository.Edit(res);
            var save =_unitOfWork.Complete();
            return save > 0;
        }

        public bool Delete(int id)
        {
            var res = GetbyId(id);
            if (res != null)
            {
                _patientRepository.Delete(id);
                _unitOfWork.Complete();
                return true;
            }
            return false;
        }
    }
}
