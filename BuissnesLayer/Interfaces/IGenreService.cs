using BuissnesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuissnesLayer.Interfaces
{
    public interface IGenreService
    {
        Task<IServiceActionResult<GenreDTO>> AddGenreAsync(string name, string parentName = null);
        Task<IServiceActionResult<GenreDTO>> DeleteGenreAsync(int key);
        Task<IServiceActionResult<GenreDTO>> UpdateGenreAsync(GenreDTO genre);
        Task<ICollection<GenreDTO>> GetAllGenresAsync();
    }
}
