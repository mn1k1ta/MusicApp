using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Music.Models
{
    public class MusicViewModel
    {
        public int MusicId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public IEnumerable<int> GenresIds { get; set; }
    }
}
