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
    public class ArtistService : IArtistService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;
        public ArtistService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _database = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IServiceActionResult<ArtistDTO>> AddArtistAsync(string artist)
        {
            if (string.IsNullOrEmpty(artist))
                return new ServiceActionResult<ArtistDTO>(false, "Artist name IS NULL OR EMPTY!");
            var artists = await FindArtistByName(artist);
            if(artists!=null)
                return new ServiceActionResult<ArtistDTO>(false, $"Genre with name: '{artist}' ALREADY EXISTS!");
            var artistToAdd = new ArtistDTO() { Name = artist };
            _database.Artists.Create(_mapper.Map<Artist>(artistToAdd));
            await _database.SaveAsync();
            return new ServiceActionResult<ArtistDTO>(true, $"Successful create genre with name: '{artist}'");
        }

        public async Task<IServiceActionResult<ArtistDTO>> DeleteArtistAsync(int key)
        {
            var artist = await _database.Artists.GetAsync(key);
            if (artist == null)
                return new ServiceActionResult<ArtistDTO>(false, $"Artist {artist.Name} is not EXIST!");
            _database.Artists.Delete(artist);
            await _database.SaveAsync();
            return new ServiceActionResult<ArtistDTO>(false, $"Artist {artist.Name} is deleted!");
        }

        public async Task<ICollection<ArtistDTO>> GetAllArtistAsync()
        {
            var artists = await _database.Artists.GetAllAsync();
            return _mapper.Map<ICollection<ArtistDTO>>(artists);
            
        }

        public async Task<IServiceActionResult<ArtistDTO>> UpdateArtistAsync(ArtistDTO artist)
        {
            if (artist == null)
                return new ServiceActionResult<ArtistDTO>(false, $"Artist is NULL!");
            var artistFromDb = await _database.Artists.GetAsync(artist.ArtistId);
            if (artistFromDb == null)
                return new ServiceActionResult<ArtistDTO>(false, $"Artist with {artist.Name} is not EXIST!");
            _database.Artists.Update(_mapper.Map<Artist>(artistFromDb));
            await _database.SaveAsync();
            return new ServiceActionResult<ArtistDTO>(false, $"Artist {artist.Name } is UPDATED");

        }

        private async Task<ArtistDTO> FindArtistByName(string name)
        {
            var artists = await _database.Artists.GetWhereAsync(p => p.Name == name);
            if (artists.Count == 0)
                return null;
            return _mapper.Map<ArtistDTO>(artists.First());

        }
    }
}
