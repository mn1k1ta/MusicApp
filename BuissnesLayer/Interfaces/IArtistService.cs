using BuissnesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuissnesLayer.Interfaces
{
    public interface IArtistService
    {
        Task<IServiceActionResult<ArtistDTO>> AddArtistAsync(string artist);
        Task<IServiceActionResult<ArtistDTO>> DeleteArtistAsync(int key);
        Task<IServiceActionResult<ArtistDTO>> UpdateArtistAsync(ArtistDTO artist);
        Task<ICollection<ArtistDTO>> GetAllArtistAsync();
    }
}
