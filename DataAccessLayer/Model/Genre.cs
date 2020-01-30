using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Model
{
    public class Genre
    {
        public int GanreId { get; set; }
        public string Name { get; set; }
        public ICollection<MusicGenre> MusicGenres { get; set; }

    }
}
