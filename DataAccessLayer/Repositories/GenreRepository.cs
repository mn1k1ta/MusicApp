using DataAccessLayer.EF;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenreRepository : BaseRepository<Genre, int>, IGenreRepository
    {
        public GenreRepository(DbContext context) : base(context)
        {               
        }
    }
}
