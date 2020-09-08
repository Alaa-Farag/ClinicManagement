using Clinic.System.DAL.DbContainer;
using Clinic.System.Entities.Models;
using Clinic.System.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;

namespace Clinic.System.DAL.Repositories.GenericRepo
{
    public abstract class Repository <T> : IRepository<T> where T : EntityBase
    {
        private readonly ClinicContext _db;
        private readonly DbSet<T> _dbSet;

        public Repository(ClinicContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }

        public virtual List<T> GetAll ()
        {
            return _dbSet.ToList();
        }

        public virtual T GetById(int id)
        {
            return _dbSet.Find(id);
        }

      
        public bool Create (T entity)
        {
            if (entity != null)
            {
                _dbSet.Add(entity);
                return true;
            }
            return false;
        }
        public bool Edit(T entity)
        {
            var result = _dbSet.Where(a => a.Id == entity.Id);
            if (result != null)
            {
                _db.Entry(entity).State = EntityState.Modified;
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                return true;
            }
            return false;
        }
    }
}
