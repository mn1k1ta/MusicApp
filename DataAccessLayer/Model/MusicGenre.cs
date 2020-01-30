using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Model
{
    public class MusicGenre
    {
        public int MusicId { get; set; }
        public int GenreId { get; set; }
        public Music Music { get; set; }
        public Genre Genre { get; set; }

    }
}
