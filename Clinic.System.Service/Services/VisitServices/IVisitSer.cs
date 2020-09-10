using Clinic.System.Service.dtos.VisitDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.System.Service.Services.VisitServices
{
   public interface IVisitSer
    {
        List<VisitGetAllDto> GetAll();
        VisitGetByIdDto GetById(int id);
        VisitCreateDto Create(VisitCreateDto visit);
    }
}
