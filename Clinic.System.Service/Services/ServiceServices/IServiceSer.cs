using Clinic.System.Service.dtos.ServiceDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.System.Service.Services.ServiceServices
{
    public interface IServiceSer
    {
        List<ServiceGetAllDto> GetAll();
        ServiceGetByIdDto GetById(int id);
        ServiceCreateDto Create(ServiceCreateDto service);
        bool Edit(ServiceEditDto service);
        bool Delete(int id);
    }
}
