using DataAccessLayer.EF;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public IEnumerable<MusicGenre> Find(Func<MusicGenre, bool> predicate)
        {
            return context.MusicGenres.Where(predicate).ToList();
        }

        public MusicGenre Get(int id)
        {
            return context.MusicGenres.Find(id);
        }

        public IEnumerable<MusicGenre> GetALL()
        {
            return context.MusicGenres;
        }

        public void Update(MusicGenre item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
    }
}
