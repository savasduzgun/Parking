﻿using Microsoft.EntityFrameworkCore;
using Parking.Data;
using Parking.Models;
using Parking.Repository.Shared.Abstract;
using System.Linq.Expressions;

namespace Parking.Repository.Shared.Concrete
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet= context.Set<T>();
        }

        public T Add(T entity)
        {
            _dbSet.Add(entity);
            Save();
            return entity;
        }

        public T Delete(T entity)
        {
            _dbSet.Remove(entity);
            Save() ;
            return entity;
        }

        public virtual T DeleteById(int id)
        {
            T entity = _dbSet.Find(id);
            if (entity != null)
            {
                entity.IsDeleted = true;
                entity.DateDeleted = DateTime.Now;
                _dbSet.Update(entity);
                Save();
            }
            return entity;
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbSet.Where(x => !x.IsDeleted);
            
        }
        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return GetAll().Where(filter);
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            return _dbSet.FirstOrDefault(filter);
        }

        public T Update(T entity)
        {
            _dbSet.Update(entity);
            Save();
            return entity;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public T GetByGuid(Guid id)
        {
            return GetFirstOrDefault(x => x.Guid == id);
        }
    }
}
