using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EF
{
   public class MusicContext:DbContext
    {
        public static readonly ILoggerFactory loggerFactory
           = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Music> Musics { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MusicArtist> MusicArtists { get; set; }
        public DbSet<MusicGenre> MusicGenres { get; set; }

        public MusicContext(DbContextOptions options) : base(options)
        {
           
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseLoggerFactory(loggerFactory);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasKey(p => p.GanreId);
            modelBuilder.Entity<MusicArtist>().HasKey(p => new { p.MusicId, p.ArtistId });
            modelBuilder.Entity<MusicGenre>().HasKey(p => new { p.MusicId, p.GenreId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
