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
    public class MusicGenreRepository:IRepository<MusicGenre>,IMusicGenreRepository
    {
        private MusicContext context;

        public MusicGenreRepository(MusicContext context)
        {
            this.context = context;
        }
        public void Create(MusicGenre item)
        {
            context.MusicGenres.Add(item);
        }

        public void Delete(int id)
        {
            MusicGenre musicgenre = context.MusicGenres.Find(id);
            if (musicgenre != null)
                context.MusicGenres.Remove(musicgenre);
        }

        public IEnumerable<MusicGenre> GetWhere(Func<MusicGenre, bool> predicate)
        {
            return context.MusicGenres.Where(predicate).ToList();
        }

        public async Task<MusicGenre> GetAsync(int id)
        {
            return await context.MusicGenres.FindAsync(id);
        }

        public IEnumerable<MusicGenre> GetAll()
        {
            return context.MusicGenres;
        }

        public void Update(MusicGenre item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
    }
}
