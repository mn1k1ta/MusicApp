using AutoMapper;
using BuissnesLayer.DTO;
using BuissnesLayer.Exception;
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
    public class MusicService : IMusicService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;

        public MusicService(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _database = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IServiceActionResult<MusicDTO>> AddMusicAsync(MusicDTO music)
        {
            if (music == null)
                return new ServiceActionResult<MusicDTO>(false, "Music for create is null");
            foreach (var item in music.GenresIds)
            {
                if (await _database.Genres.GetAsync(item) == null)
                {
                    throw new ServiceException($"{item} genres id is NULL!");
                }
            }
            var musicToCreate = _mapper.Map<Music>(music);
            _database.Musics.Create(musicToCreate);
            //await _database.SaveAsync();
           
            await AttachMusicToGenresAsync(music.GenresIds, musicToCreate);
            await _database.SaveAsync();
            var returnedMusic = _mapper.Map<MusicDTO>(musicToCreate);
            returnedMusic.GenresIds = music.GenresIds;
            return new ServiceActionResult<MusicDTO>(true, $"Music with name: '{music.Name}' created!", returnedMusic);
        }

        public async Task<IServiceActionResult<MusicDTO>> DeleteMusicAsync(int key)
        {
            if (key <= 0)
                return new ServiceActionResult<MusicDTO>(false, $"Incorrect key: '{key}'!");
            var musicToDelete = await _database.Musics.GetAsync(key);
            if (musicToDelete == null)
                return new ServiceActionResult<MusicDTO>(false, $"Music with id: '{key}' NOT FOUND!");
            _database.Musics.Delete(musicToDelete);
            await _database.SaveAsync();
            return new ServiceActionResult<MusicDTO>(true, $"Game with id: '{key}' deleted!", _mapper.Map<MusicDTO>(musicToDelete));
        }

        public async Task<ICollection<MusicDTO>> GetAllMusicAsync()
        {
            var musics = await _database.Musics.GetAllAsync();
            var musicDTOs = _mapper.Map<ICollection<MusicDTO>>(musics);
            await AttachGenresToMusicDTOAsync(musicDTOs);
            return musicDTOs;
        }

        public async Task<ICollection<MusicDTO>> GetAllMusicByGenreAsync(IEnumerable<int> genreIds)
        {
            if (genreIds == null)
                throw new ServiceException("Array of IDs is NULL!");
            var music = await _database.Musics.GetAllIncludingAsync(p => p.MusicGenres);
            var musicByGenreIds = music.Where(music => genreIds.All(id => music.MusicGenres.Any(musicGenre => musicGenre.GenreId == id)));
            var musicDTOs = _mapper.Map<ICollection<MusicDTO>>(musicByGenreIds);
            await AttachGenresToMusicDTOAsync(musicDTOs);
            return musicDTOs;
        }

        public async Task<ICollection<MusicDTO>> GetMusicByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
                return null;
            var music = await _database.Musics.GetWhereAsync(g => g.Name.Contains(name));
            var musicsDTOs = _mapper.Map<ICollection<MusicDTO>>(music);
            await AttachGenresToMusicDTOAsync(musicsDTOs);
            return musicsDTOs;
        }

        public async Task<IServiceActionResult<MusicDTO>> UpdateMusicAsync(MusicDTO music)
        {
            if (music == null)
                return new ServiceActionResult<MusicDTO>(false, $"Music is NULL!");
            var musicFromDb = await _database.Musics.GetAsync(music.MusicId);
            if (musicFromDb == null)              
                return new ServiceActionResult<MusicDTO>(false, $"Music with id: '{music.MusicId}' NOT EXISTS!");
            _database.Musics.Update(_mapper.Map(music,musicFromDb));
            await _database.SaveAsync();
            return new ServiceActionResult<MusicDTO>(true, $"Muisc with id: '{music.MusicId}' UPDATED!", music);
        }

        public async Task AttachMusicToGenresAsync(IEnumerable<int> genresIds, Music music)
        {
            if (genresIds == null)
                throw new ServiceException("Array with genres id is NULL!");
            
            //var music = await _database.Musics.GetAsync(musicId);
            //if (music == null)
            //    throw new ServiceException($"Music with this id is NULL!");
            var genres = await _database.Genres.GetWhereAsync(gnr => genresIds.Contains(gnr.GanreId));
            foreach (var gnr in genres)
            {
                _database.MusicGanres.Create(new MusicGenre { MusicId=music.MusicId, GenreId = gnr.GanreId });
            }
        }
    
        private async Task AttachGenresToMusicDTOAsync(IEnumerable<MusicDTO> musics)
        {
            if (musics == null)
                throw new ServiceException("Music in NULL!");
            //var listOfTasks = new List<Task>();
            foreach (var music in musics)
                await GetAllGenresIdByGameIdAsync(music);
            //await Task.WhenAll(listOfTasks);
        }
        private async Task GetAllGenresIdByGameIdAsync(MusicDTO music)
        {
            if (music == null)
                throw new ServiceException("Music is NULL!");
            var genresByMusicId = await _database.MusicGanres.GetWhereAsync(g => g.MusicId == music.MusicId);
            music.GenresIds = genresByMusicId.Select(x => x.GenreId);
        }
    }
}
