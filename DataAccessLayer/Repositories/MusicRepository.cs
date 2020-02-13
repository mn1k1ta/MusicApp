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
    public class MusicRepository : IRepository<Music>,IMusicRepository
    {
        private MusicContext context;

        public MusicRepository(MusicContext context)
        {
            this.context = context;
        }
        public void Create(Music item)
        {
            context.Musics.Add(item);
        }

        public void Delete(int id)
        {
            Music music = context.Musics.Find(id);
            if (music != null)
                context.Musics.Remove(music);
        }

        public IEnumerable<Music> GetWhere(Func<Music, bool> predicate)
        {
            return context.Musics.Where(predicate).ToList();
        }

        public async Task<Music> GetAsync(int id)
        {
            return await context.Musics.FindAsync(id);
        }

        public IEnumerable<Music> GetAll()
        {
            return context.Musics;
        }

        public void Update(Music item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
    }
}
