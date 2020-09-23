using Clinic.System.Entities.Models;
using Clinic.System.Interface;
using Clinic.System.Service.dtos.DoctorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinic.System.Service.Services.DoctorServices
{
    public class DoctorSer: IDoctorSer
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDoctorRepository _doctorRepository;

        public DoctorSer(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _doctorRepository = _unitOfWork.GetDoctorRepo();
        }

        public List<DoctorGetAllDto> GetAll()
        {
           var result =  _doctorRepository.GetAll().Select(a => new DoctorGetAllDto {
                        Id=a.Id,
                        Name=a.Name,
                        Phone=a.Phone,
                        Services=a.DoctorServices.Select(a=>a.Service)
            });

            return result.ToList();
        }

        public DoctorGetByIdDto GetById(int id)
        {
            var result = _doctorRepository.GetById(id);
            var doctor = new DoctorGetByIdDto();
            doctor.Id = result.Id;
            doctor.Name = result.Name;
            doctor.Phone = result.Phone;
            doctor.Services = result.DoctorServices.Select(a => a.Service);

            return doctor;
        }

        public List<GetDoctorsByServiceIdDto> GetDoctorsByServiceId(int serviceId)
        {
            var result = _doctorRepository.GetDoctorsByServiceId(serviceId)
                .Select(a=> new GetDoctorsByServiceIdDto {
                        Id=a.Id ,
                        Name=a.Name
                }).ToList();

            return result;
        }

        public DoctorCreateDto Create(DoctorCreateDto doctor)
        {
            if (doctor != null)
            {
                var doc = new Doctor();
                doc.Id = doctor.Id;
                doc.Name = doctor.Name;
                doc.Phone = doctor.Phone;
                _doctorRepository.Create(doc);
                _unitOfWork.Complete();
            }
            return doctor;
        }

        public bool Edit (DoctorEditDto doctor)
        {

            if (doctor != null)
            {
                var doc = new Doctor();
                doc.Id = doctor.Id;
                doc.Name = doctor.Name;
                doc.Phone = doctor.Phone;
                _doctorRepository.Edit(doc);
                _unitOfWork.Complete();

                return true;
            }

            return false;
        }

        public bool Delete (int id)
        {
            var res = GetById(id);
            if (res != null)
            {
                _doctorRepository.Delete(id);
                _unitOfWork.Complete();
                return true;
            }
            return false;
        }
    }
}
