using AutoMapper;
using BuissnesLayer.DTO;
using BuissnesLayer.Helpers;
using BuissnesLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnesLayer.Services
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;

        public GenreService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _database = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IServiceActionResult<GenreDTO>> AddGenreAsync(string name, string parentName = null)
        {
            if (string.IsNullOrEmpty(name))
                return new ServiceActionResult<GenreDTO>(false, "Genre name IS NULL OR EMPTY!");
            var genreWithEqualsName = await FindGenreByNameAsync(name);
            //if (genreWithEqualsName != null)
            //    return new ServiceActionResult<GenreDTO>(false, $"Genre with name: '{name}' ALREADY EXISTS!");
            GenreDTO parentGenre = null;
            if (parentName != null)
                parentGenre = await FindGenreByNameAsync(parentName);
            var genreToAdd = new GenreDTO() { Name = name};
            _database.Genres.Create(_mapper.Map<Genre>(genreToAdd));
            await _database.SaveAsync();
            return new ServiceActionResult<GenreDTO>(true, $"Successful create genre with name: '{name}'");
        }

        public async Task<IServiceActionResult<GenreDTO>> DeleteGenreAsync(int key)
        {
            if (key <= 0)
                return new ServiceActionResult<GenreDTO>(false, $"Incorrect key: {key}!");
            var genreFromDb = await _database.Genres.GetAsync(key);
            if (genreFromDb == null)
                return new ServiceActionResult<GenreDTO>(false, $"Genre with id: {key} NOT EXISTS!");
            _database.Genres.Delete(genreFromDb);
            await _database.SaveAsync();
            return new ServiceActionResult<GenreDTO>(true, "Successful remove genre!", _mapper.Map<GenreDTO>(genreFromDb));
        }

        public async Task<ICollection<GenreDTO>> GetAllGenresAsync()
        {
            var genres = await _database.Genres.GetAllAsync();
            return _mapper.Map<ICollection<GenreDTO>>(genres);
        }

        public async Task<IServiceActionResult<GenreDTO>> UpdateGenreAsync(GenreDTO genre)
        {
            if (genre == null)
                return new ServiceActionResult<GenreDTO>(false, "Genre is null!");
            var genreFromDb = await _database.Genres.GetAsync(genre.GanreId);
            if (genreFromDb == null)
                return new ServiceActionResult<GenreDTO>(false, $"Genre with id {genre.GanreId} NOT EXISTS!");
            //var genreToUpdate = _mapper.Map<Genre>(genre);
            _database.Genres.Update(_mapper.Map(genre, genreFromDb));
            await _database.SaveAsync();
            return new ServiceActionResult<GenreDTO>(true, "Successful updating genre!", genre);
        }

        private async Task<GenreDTO> FindGenreByNameAsync(string name)
        {
            //if (string.IsNullOrEmpty(name))
            //    throw new ServiceException("Genre name is null or empty!");
            var genres = await _database.Genres.GetWhereAsync(p => p.Name == name);
            if (genres.Count == 0)
                return null;
            return _mapper.Map<GenreDTO>(genres.First());
        }
    }
}
