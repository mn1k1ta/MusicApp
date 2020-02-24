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
    class MusicArtistRepository : BaseRepository<MusicArtist, int>, IMusicArtistRepository
    {
        public MusicArtistRepository(DbContext context): base(context)
        {           
        }
    }
}
