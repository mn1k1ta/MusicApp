using DataAccessLayer.EF;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ArtistRepository : BaseRepository<Artist,int>, IArtistRepository
    {
        public ArtistRepository(DbContext context) : base(context)
        {               
        }
    }
}
