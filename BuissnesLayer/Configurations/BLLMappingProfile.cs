using BuissnesLayer.DTO;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer.Configurations
{
    class BLLMappingProfile
    {
        CreateMap<Genre, GenreDTO>().ReverseMap();
    }
}
