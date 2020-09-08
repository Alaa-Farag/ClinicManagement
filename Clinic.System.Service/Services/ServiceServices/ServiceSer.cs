using Clinic.System.Entities.Models;
using Clinic.System.Interface;
using Clinic.System.Service.dtos.ServiceDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinic.System.Service.Services.ServiceServices
{
   public class ServiceSer: IServiceSer
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceRepository _serviceRepository;

        public ServiceSer(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _serviceRepository = _unitOfWork.GetServiceRepo();
        }

        public List<ServiceGetAllDto> GetAll()
        {
            var result= _serviceRepository.GetAll()
                        .Select(a=> new ServiceGetAllDto {
                        Id=a.Id,
                        Name=a.Name,
                        Price=a.Price
                        }).ToList();

            return result;
        }

        public ServiceGetByIdDto GetById(int id)
        {
            var result = _serviceRepository.GetById(id);
            var service = new ServiceGetByIdDto();
            service.Id = result.Id;
            service.Name = result.Name;
            service.Price = result.Price;
            return service;
        }

        public ServiceCreateDto Create (ServiceCreateDto service)
        {
            if (service!=null)
            {
                var serv = new Clinic.System.Entities.Models.Service();
                serv.Name = service.Name;
                serv.Price = service.Price;
                _serviceRepository.Create(serv);
                _unitOfWork.Complete();
            }
            return service;
        }

        public bool Edit (ServiceEditDto service)
        {
            if (service != null)
            {
                var serv = new Clinic.System.Entities.Models.Service();
                serv.Id = service.Id;
                serv.Name = service.Name;
                serv.Price = service.Price;
                _serviceRepository.Edit(serv);
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
                _serviceRepository.Delete(id);
                _unitOfWork.Complete();
                return true;
            }
            return false;
        }
    }
}
