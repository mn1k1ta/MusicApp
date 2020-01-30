using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Model
{
    public class Music
    {
        public int MusicId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<MusicArtist> MusicArtists { get; set; }
        public ICollection<MusicGenre> MusicGenres { get; set; }
    }
}
