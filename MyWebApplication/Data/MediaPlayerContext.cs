using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWebApplication.Data.Entities;

namespace MyWebApplication.Data
{
	public class MediaPlayerContext
	{
		public List<TrackEntity> TrackContextEntities { get; set; }
		public List<AlbumEntity> AlbumContextEntities { get; set; }
		public List<ArtistEntity> ArtistContextEntities { get; set; }
		public List<BandEntity> BandContextEntities { get; set; }

		public MediaPlayerContext()//DbContextOptions<MediaPlayerContext> options) : base(options)
		{
			TrackContextEntities = new List<TrackEntity>();
			AlbumContextEntities = new List<AlbumEntity>();
			ArtistContextEntities = new List<ArtistEntity>();
			BandContextEntities = new List<BandEntity>();
			MediaPlayerInitializer.Initialize(this);
		}

	}
}
