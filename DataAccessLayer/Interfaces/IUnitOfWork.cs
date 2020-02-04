using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    interface IUnitOfWork:IDisposable
    {
        IRepository<Music> Musics { get; }
        IRepository<IArtist> Artist { get; }
        IRepository<IGenre> Genre { get; }
        IRepository<IMusicArtist> MusicArtist { get; }
        IRepository<IMusicGenre> MusicGanre { get; }

        void Save();

    }
}
