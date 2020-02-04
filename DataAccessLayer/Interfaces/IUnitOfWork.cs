using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<Model.Music> Musics { get; }
        IRepository<Artist> Artists { get; }
        IRepository<Genre> Genres { get; }
        IRepository<MusicArtist> MusicArtists { get; }
        IRepository<MusicGenre> MusicGanres { get; }

        void Save();

    }
}
