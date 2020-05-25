 using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Tokens;
using MyWebApplication.Data;
using MyWebApplication.Data.Entities;
using MyWebApplication.Data.Repositories;
using MyWebApplication.Data.UnitOfWork;
using MyWebApplication.Domain.Interfaces;
using MyWebApplication.Domain.Models;
using MyWebApplication.Domain.Services;

namespace MyApiApplication
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
			services.AddSingleton(new MapperConfiguration(c => c.AddProfile(new MyWebApplication.Domain.Mapper())).CreateMapper());
			services.AddTransient<IAlbumService, AlbumService>();
			services.AddTransient<IArtistService, ArtistService>();
			services.AddTransient<IBandService, BandService>();
			services.AddTransient<ITrackService, TrackService>();

			services.AddIdentity<AppUser, IdentityRole>(options => options.SignIn.RequireConfirmedEmail = false)
					.AddEntityFrameworkStores<MediaPlayerContext>()
					.AddDefaultTokenProviders();

			JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
			services
				.AddAuthentication(options =>
				{
					options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
					options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
					options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

				})
				.AddJwtBearer(cfg =>
				{
					cfg.RequireHttpsMetadata = false;
					cfg.SaveToken = true;
					cfg.TokenValidationParameters = new TokenValidationParameters
					{
						ValidIssuer = Configuration["SecurityConfig:JwtIssuer"],
						ValidAudience = Configuration["SecurityConfig:JwtIssuer"],
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecurityConfig:JwtKey"])),
						ClockSkew = TimeSpan.Zero
					};
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

			app.UseAuthentication();

			app.UseMvc();
		}
	}
}
