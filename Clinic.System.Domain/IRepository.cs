using Clinic.System.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Clinic.System.Interface
{
   public interface IRepository <T> where T : EntityBase
    {
        List<T> GetAll();
        T GetById(int id);
        bool Create(T entity);
        bool Edit(T entity);
        bool Delete(int id);
    }
}
