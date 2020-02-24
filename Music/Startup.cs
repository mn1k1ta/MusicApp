using System;
using System.Collections.Generic;
using System.Linq;

using AutoMapper;
using BuissnesLayer.Configurations;
using BuissnesLayer.DTO;
using BuissnesLayer.Interfaces;
using BuissnesLayer.Services;
using DataAccessLayer.EF;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Music.Models;

namespace Music
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MusicContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MusicStoreDb")));

            // Configure AutoMapper.
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new BLLMappingProfile());
                mc.CreateMap<MusicDTO, MusicViewModel>().ReverseMap();
                mc.CreateMap<GenreDTO, GenreViewModel>().ReverseMap();
                //mc.AddProfile(new WebApiMappingProfile());
            });
            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            // Configure services DI.
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
            services.AddScoped<DbContext, MusicContext>();
            services.AddScoped<IGenreService, GenreService>();           
            services.AddScoped<IMusicService, MusicService>();
            services.AddScoped<IArtistService, ArtistService>();

            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthorization();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
