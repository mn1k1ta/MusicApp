using DataAccessLayer.EF;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ArtistRepository:IRepository<Artist>,IArtistRepository
    {
        private MusicContext context;

        public ArtistRepository(MusicContext context)
        {
            this.context = context;
        }
        public void Create(Artist item)
        {
            context.Artists.Add(item);
        }

        public void Delete(int id)
        {
            Artist artist = context.Artists.Find(id);
            if (artist != null)
                context.Artists.Remove(artist);
        }

        public IEnumerable<Artist> GetWhere(Func<Artist, bool> predicate)
        {
            return context.Artists.Where(predicate).ToList();
        }

        public async Task<Artist> GetAsync(int id)
        {
            return await context.Artists.FindAsync(id);
        }

        public IEnumerable<Artist> GetAll()
        {
            return context.Artists;
        }

        public void Update(Artist item)
        {
            context.Entry(item).State = EntityState.Modified;
        }

        public virtual async Task<ICollection<Artist>> GetAllAsync()
        {
            return await _entity.ToListAsync();
        }

        public virtual async Task<ICollection<Artist>> GetWhereAsync(Expression<Func<Artist, bool>> expression)
        {
            return await GetWhere(expression).ToListAsync();
        }

        public virtual async Task<ICollection<Artist>> GetAllIncludingAsync(params Expression<Func<Artist, object>>[] includeProperties)
        {
            return await GetAllIncluding(includeProperties).ToListAsync();
        }
    }
}
