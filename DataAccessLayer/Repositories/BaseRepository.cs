using DataAccessLayer.EF;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IRepository<TEntity>
        where TEntity : class
        where TKey : struct
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _entity;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _entity = _context.Set<TEntity>();
        }
        public void Create(TEntity item)
        {
            _entity.Add(item);
        }

        public void Delete(int id)
        {
            TEntity artist = _entity.Find(id);
            if (artist != null)
                _entity.Remove(artist);
        }

        public IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> expression)
        {
            return _entity.AsNoTracking().Where(expression);
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await _entity.FindAsync(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _entity;
        }

        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await _entity.ToListAsync();
        }

        public async Task<ICollection<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await GetWhere(expression).ToListAsync();
        }

        public async Task<ICollection<TEntity>> GetAllIncludingAsync(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await GetAllIncluding(includeProperties).ToListAsync();
        }
        public IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var queryable = GetAll();
            foreach (var includeProperty in includeProperties)
                queryable = queryable.Include(includeProperty);
            return queryable;
        }
    }
}
