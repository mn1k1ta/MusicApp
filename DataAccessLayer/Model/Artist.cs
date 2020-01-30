using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Model
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public ICollection<MusicArtist> ArtistMusics { get; set; }
     

    }
}
