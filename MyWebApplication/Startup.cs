using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyWebApplication.Domain.Services;
using MyWebApplication.Data.Entities;
using MyWebApplication.Domain.Interfaces;
using AutoMapper;
using MyWebApplication.Domain.Models;
using MyWebApplication.Data;
using MyWebApplication.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using MyWebApplication.Data.UnitOfWork;

namespace MyWebApplication
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
            services.AddDbContext<MediaPlayerContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("MediaPlayerDatabase")));
            services.AddScoped<IRepository<AlbumEntity>, Repository<AlbumEntity>>();
            services.AddScoped<IRepository<ArtistEntity>, Repository<ArtistEntity>>();
            services.AddScoped<IRepository<BandEntity>, Repository<BandEntity>>();
            services.AddScoped<IRepository<TrackEntity>, Repository<TrackEntity>>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton(new MapperConfiguration(c => c.AddProfile(new Domain.Mapper())).CreateMapper());
            services.AddTransient<IAlbumService, AlbumService>();
            services.AddTransient<IArtistService, ArtistService>();
            services.AddTransient<IBandService, BandService>();
            services.AddTransient<ITrackService, TrackService>();


            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=MediaPlayer}/{action=Index}/{id?}");
            });
        }
    }
}
