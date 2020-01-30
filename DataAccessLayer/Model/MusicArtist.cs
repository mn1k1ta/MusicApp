using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Model
{
   public  class MusicArtist
    {
        public int MusicId { get; set; }
        public int ArtistId {get;set;}
        public Music Music { get; set; }
        public Artist Artist { get; set; }
    }
}
