using BuissnesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuissnesLayer.Interfaces
{
     public interface IMusicService
    {
        Task<IServiceActionResult<MusicDTO>> AddMusicAsync(MusicDTO music);
        Task<IServiceActionResult<MusicDTO>> DeleteMusicAsync(int key);
        Task<IServiceActionResult<MusicDTO>> UpdateMusicAsync(MusicDTO music);
        Task<ICollection<MusicDTO>> GetAllMusicAsync();
        Task<ICollection<MusicDTO>> GetAllMusicByGenreAsync(IEnumerable<int> genreIds);
        Task<ICollection<MusicDTO>> GetMusicByNameAsync(string name);
    }
}
