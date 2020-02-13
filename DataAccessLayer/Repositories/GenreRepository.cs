using DataAccessLayer.EF;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenreRepository:IRepository<Genre>,IGenreRepository
    {
        private MusicContext context;

        public GenreRepository(MusicContext context)
        {
            this.context = context;
        }
        public void Create(Genre item)
        {
            context.Genres.Add(item);
        }

        public void Delete(int id)
        {
            Genre genre = context.Genres.Find(id);
            if (genre != null)
                context.Genres.Remove(genre);
        }

        public IEnumerable<Genre> GetWhere(Func<Genre, bool> predicate)
        {
            return context.Genres.Where(predicate).ToList();
        }

        public async Task<Genre> GetAsync(int id)
        {
            return await context.Genres.FindAsync(id);
        }

        public IEnumerable<Genre> GetAll()
        {
            return context.Genres;
        }
        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await context.Genres;
        }

        public void Update(Genre item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
    }
}
