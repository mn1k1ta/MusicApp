using BuissnesLayer.DTO;
using DataAccessLayer.Model;
using AutoMapper;

namespace BuissnesLayer.Configurations
{
    public class BLLMappingProfile : Profile
    {
        public BLLMappingProfile()
        {
            CreateMap<Music, MusicDTO>().ReverseMap();
            CreateMap<Genre, GenreDTO>().ReverseMap();
            CreateMap<Artist, ArtistDTO>().ReverseMap();
        }
       
    }
}
