using DataAccessLayer.EF;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Model;
using System;

namespace DataAccessLayer.Repositories
{
    public class EFUnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MusicContext context;

        private IMusicRepository _musicRepository;
        private IArtistRepository _artistRepository;
        private IGenreRepository _genreRepository;
        private IMusicArtistRepository _musicartistRepository;
        private IMusicGenreRepository _musicgenreRepository;

        public EFUnitOfWork(MusicContext context)
        {
            this.context = context;
        }

        public IRepository<Model.Music> Musics
        {
            get
            {
                if (_musicRepository == null)
                    _musicRepository = new MusicRepository(context);
                return _musicRepository;
            }
        }

        public IRepository<Artist> Artists
        {
            get
            {
                if (_artistRepository == null)
                    _artistRepository = new ArtistRepository(context);
                return _artistRepository;
            }
        }

        public IRepository<Genre> Genres
        {
            get
            {
                if (_genreRepository == null)
                    _genreRepository = new GenreRepository(context);
                return _genreRepository;
            }
        }

        public IRepository<MusicArtist> MusicArtists
        {
            get
            {
                if (_musicartistRepository == null)
                    _musicartistRepository = new MusicArtistRepository(context);
                return _musicartistRepository;
            }
        }


        public IRepository<MusicGenre> MusicGanres
        {
            get
            {
                if (_musicgenreRepository == null)
                    _musicgenreRepository = new MusicGenreRepository(context);
                return _musicgenreRepository;
            }
        }


        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}