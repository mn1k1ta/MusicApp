using DataAccessLayer.EF;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<Artist> Find(Func<Artist, bool> predicate)
        {
            return context.Artists.Where(predicate).ToList();
        }

        public Artist Get(int id)
        {
            return context.Artists.Find(id);
        }

        public IEnumerable<Artist> GetALL()
        {
            return context.Artists;
        }

        public void Update(Artist item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
    }
}
