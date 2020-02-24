using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer.DTO
{
    public class GenreDTO
    {
        public int GanreId { get; set; }
        public string Name { get; set; }
        public int? ParentGenreId { get; set; }
    }
}
