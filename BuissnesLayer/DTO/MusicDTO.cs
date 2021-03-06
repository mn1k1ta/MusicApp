﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer.DTO
{
    public class MusicDTO
    {
        public int MusicId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<int> GenresIds { get; set; }
    }
}
