using DataAccessLayer.EF;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<Music> Find(Func<Music, bool> predicate)
        {
            return context.Musics.Where(predicate).ToList();
        }

        public Music Get(int id)
        {
            return context.Musics.Find(id);
        }

        public IEnumerable<Music> GetALL()
        {
            return context.Musics;
        }

        public void Update(Music item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
    }
}
