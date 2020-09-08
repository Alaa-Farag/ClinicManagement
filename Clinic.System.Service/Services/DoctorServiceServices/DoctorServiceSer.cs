using Clinic.System.Entities.Models;
using Clinic.System.Interface;
using Clinic.System.Service.dtos.DoctorServiceDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinic.System.Service.Services.DoctorServiceServices
{
    public class DoctorServiceSer: IDoctorServiceSer
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDoctorServiceRepository _doctorServiceRepository;

        public DoctorServiceSer(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _doctorServiceRepository = _unitOfWork.GetDoctorServiceRepo();
        }

        public List<DoctorServiceGetAllDto> GetAll()
        {
            var res = _doctorServiceRepository.GetAll()
                .Select(a => new DoctorServiceGetAllDto { 
                    Id=a.Id,
                    DoctorName=a.Doctor.Name,
                    DoctorPhone=a.Doctor.Phone,
                    ServiceName=a.Service.Name,
                    ServicePrice=a.Service.Price
                      }).ToList();

            return res;
        }

        public DoctorServiceGetByIdDto GetById(int id)
        {
            var result = _doctorServiceRepository.GetById(id);
            var DocService = new DoctorServiceGetByIdDto();
            DocService.Id = result.Id;
            DocService.DoctorName = result.Doctor.Name;
            DocService.DoctorPhone = result.Doctor.Phone;
            DocService.ServiceName = result.Service.Name;
            DocService.ServicePrice = result.Service.Price;

            return DocService;
        }

        public DoctorServiceCreateDto Create (DoctorServiceCreateDto doctorService)
        {
            if (doctorService != null)
            {
                var NewDoctorService = new DoctorService();
                NewDoctorService.DoctorId = doctorService.DoctorId;
                NewDoctorService.ServiceId = doctorService.ServiceId;
                _doctorServiceRepository.Create(NewDoctorService);
                _unitOfWork.Complete();
            }

            return doctorService;
        }

        public bool Edit (DoctorServiceEditDto doctorService)
        {
            if (doctorService != null)
            {
                var NewDoctorService = new DoctorService();
                NewDoctorService.Id = doctorService.Id;
                NewDoctorService.DoctorId = doctorService.DoctorId;
                NewDoctorService.ServiceId = doctorService.ServiceId;
                _doctorServiceRepository.Edit(NewDoctorService);
                _unitOfWork.Complete();

                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            var res = GetById(id);
            if (res != null)
            {
                _doctorServiceRepository.Delete(id);
                _unitOfWork.Complete();
                return true;
            }
            return false;
        }
    }
}
