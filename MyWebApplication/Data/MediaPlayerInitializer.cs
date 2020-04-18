using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWebApplication.Data.Entities;

namespace MyWebApplication.Data
{
	public class MediaPlayerInitializer
	{
		private static bool initialized = false;
		public static void Initialize(MediaPlayerContext context)
		{
			if (initialized)
			{
				return;
			}

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();

			ArtistEntity DevonPortielje = new ArtistEntity()
			{
				Name = "Devon Portielje"
			};

			ArtistEntity ConnerMolander = new ArtistEntity()
			{
				Name = "Conner Molander"
			};

			ArtistEntity DylanPhillips = new ArtistEntity()
			{
				Name = "Dylan Phillips"
			};

			ArtistEntity IsaacSymonds = new ArtistEntity()
			{
				Name = "Isaac Symonds"
			};

			ArtistEntity TylerJoseph = new ArtistEntity()
			{
				Name = "Tyler Joseph"
			};

			ArtistEntity JoshDun = new ArtistEntity()
			{
				Name = "Josh Dun"
			};

			TrackEntity ThenAgain = new TrackEntity()
			{
				Name = "Then Again",
				Length = 199,
				ReleaseDate = new DateTime(2019, 11, 1)
			};

			TrackEntity FavouriteBoy = new TrackEntity()
			{
				Name = "Favourite Boy",
				Length = 242,
				ReleaseDate = new DateTime(2019, 11, 1)
			};

			TrackEntity Jumpsuit = new TrackEntity()
			{
				Name = "Jumpsuit",
				Length = 239,
				ReleaseDate = new DateTime(2018, 10, 5)
			};

			TrackEntity Levitate = new TrackEntity()
			{
				Name = "Levitate",
				Length = 146,
				ReleaseDate = new DateTime(2018, 10, 5)
			};

			TrackEntity Morph = new TrackEntity()
			{
				Name = "Morph",
				Length = 259,
				ReleaseDate = new DateTime(2018, 10, 5)
			};

			AlbumEntity ABlemishInTheGreatLight = new AlbumEntity()
			{
				Name = "A Blemish in the Great Light",
				TrackEntities = new List<TrackEntity>() { ThenAgain, FavouriteBoy }
			};

			AlbumEntity Trench = new AlbumEntity()
			{
				Name = "Trench",
				TrackEntities = new List<TrackEntity>() { Jumpsuit, Levitate, Morph }
			};

			BandEntity HalfMoonRun = new BandEntity()
			{
				Name = "Half Moon Run",
				AlbumEntities = new List<AlbumEntity>() { ABlemishInTheGreatLight },
				ArtistEntities = new List<ArtistEntity>() { DevonPortielje, ConnerMolander, DylanPhillips, IsaacSymonds }
			};

			BandEntity TwentyOnePilots = new BandEntity()
			{
				Name = "twenty one pilots",
				AlbumEntities = new List<AlbumEntity>() { Trench },
				ArtistEntities = new List<ArtistEntity>() { TylerJoseph, JoshDun }
			};

			context.BandContextEntities.Add(HalfMoonRun);
			context.BandContextEntities.Add(TwentyOnePilots);

			context.SaveChanges();

			initialized = true;
		}
	}
}
