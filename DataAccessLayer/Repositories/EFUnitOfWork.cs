using DataAccessLayer.EF;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repositories
{
    class EFUnitOfWork : IUnitOfWork
    {
        private readonly MusicContext context;

        private readonly MusicRepository _musicRepository;
        private readonly ArtistRepository _artistRepository;
        private readonly GenreRepository _genreRepository;
        private readonly Music musicRepository;

        public EFUnitOfWork(MusicContext context)
        {
            this.context = context;
        }

        public IRepository<Music> Musics
        {
            get
            {
                if (MusicRepository == null)
                   musicRepository = new MusicRepository(db);
                return musicRepository;
            }
        }

        public IRepository<Artist> Artist => throw new NotImplementedException();

        public IRepository<Genre> Genre => throw new NotImplementedException();

        public IRepository<MusicArtist> MusicArtist => throw new NotImplementedException();

        public IRepository<MusicGenre> MusicGanre => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
