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
    class MusicArtistRepository : IRepository<MusicArtist>, IMusicArtistRepository
    {
        private readonly MusicContext _context;

        public MusicArtistRepository(MusicContext context)
        {
            this._context = context;
        }
        public void Create(MusicArtist item)
        {
            _context.MusicArtists.Add(item);
        }

        public void Delete(int id)
        {
            MusicArtist musicArtist = _context.MusicArtists.Find(id);
            if (musicArtist != null)
                _context.MusicArtists.Remove(musicArtist);
        }

        public IEnumerable<MusicArtist> GetWhere(Func<MusicArtist, bool> predicate)
        {
            return _context.MusicArtists.Where(predicate).ToList();
        }

        public async Task<MusicArtist> GetAsync(int id)
        {
            return await _context.MusicArtists.FindAsync(id);
        }

        public IEnumerable<MusicArtist> GetAll()
        {
            return _context.MusicArtists;
        }

        public void Update(MusicArtist item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
