using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Music.Models
{
    public class GenreViewModel
    {
        public int GanreId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
