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
    class MusicArtistRepository:IRepository<MusicArtist>,IMusicArtistRepository
    {
        private MusicContext context;

        public MusicArtistRepository(MusicContext context)
        {
            this.context = context;
        }
        public void Create(MusicArtist item)
        {
            context.MusicArtists.Add(item);
        }

        public void Delete(int id)
        {
            MusicArtist musicartist = context.MusicArtists.Find(id);
            if (musicartist != null)
                context.MusicArtists.Remove(musicartist);
        }

        public IEnumerable<MusicArtist> Find(Func<MusicArtist, bool> predicate)
        {
            return context.MusicArtists.Where(predicate).ToList();
        }

        public MusicArtist Get(int id)
        {
            return context.MusicArtists.Find(id);
        }

        public IEnumerable<MusicArtist> GetALL()
        {
            return context.MusicArtists;
        }

        public void Update(MusicArtist item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
    }
}
