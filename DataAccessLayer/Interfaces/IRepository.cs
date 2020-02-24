using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IRepository<T> where T:class
    {
        IQueryable<T> GetAll();
        Task<T> GetAsync(int id);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
        void Create(T item);
        void Update(T item);
        void Delete(T item);
        Task<ICollection<T>> GetAllAsync();
        Task<ICollection<T>> GetWhereAsync(Expression<Func<T, bool>> expression);
        Task<ICollection<T>> GetAllIncludingAsync(params Expression<Func<T, object>>[] includeProperties);

    }
}
