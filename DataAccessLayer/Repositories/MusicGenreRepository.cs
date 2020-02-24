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
    public class MusicGenreRepository : BaseRepository<MusicGenre, int>, IMusicGenreRepository
    {
        public MusicGenreRepository(DbContext context) : base(context)
        {
        }
    }
}
