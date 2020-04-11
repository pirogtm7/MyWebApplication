﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWebApplication.Data.Entities;

namespace MyWebApplication.Data
{
	public class MediaPlayerContext : DbContext
	{
		public DbSet<TrackEntity> TrackContextEntities { get; set; }
		public DbSet<AlbumEntity> AlbumContextEntities { get; set; }
		public DbSet<ArtistEntity> Artists { get; set; }
		public DbSet<BandEntity> BandContextEntities { get; set; }

		public MediaPlayerContext()//DbContextOptions<MediaPlayerContext> options) : base(options)
		{
			MediaPlayerInitializer.Initialize(this);
		}

	}
}
