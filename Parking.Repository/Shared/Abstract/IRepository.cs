using Parking.Models;
using System.Linq.Expressions;

namespace Parking.Repository.Shared.Abstract
{
    public interface IRepository<T> where T : BaseModel
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter);
        T GetById(int id);
        T GetFirstOrDefault(Expression<Func<T, bool>> filter);
        T Add(T entity);
        T Update(T entity);
        T DeleteById(int id);
        T Delete(T entity);
        void Save();
    }
}
