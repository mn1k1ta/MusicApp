using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IMusicRepository Musics { get; }
       IArtistRepository Artists { get; }
        IRepository<Genre> Genres { get; }
        IRepository<MusicArtist> MusicArtists { get; }
        IRepository<MusicGenre> MusicGanres { get; }

        Task SaveAsync();

    }
}
