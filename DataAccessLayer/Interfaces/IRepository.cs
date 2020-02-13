using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        Task<T> GetAsync(int id);
        IEnumerable<T> GetWhere(Func<T, Boolean> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        Task<ICollection<T>> GetAllAsync();
        Task<ICollection<T>> GetWhereAsync(Expression<Func<T, bool>> expression);
        Task<ICollection<T>> GetAllIncludingAsync(params Expression<Func<T, object>>[] includeProperties);

    }
}
