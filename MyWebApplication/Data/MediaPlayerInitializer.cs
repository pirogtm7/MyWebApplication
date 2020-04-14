using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWebApplication.Data.Entities;

namespace MyWebApplication.Data
{
	public static class MediaPlayerInitializer
	{
		public static void Initialize(MediaPlayerContext context)
		{
			//context.Database.EnsureDeleted();
			//context.Database.EnsureCreated();
			//if (!context.ArtistContextEntities.Any())
			//{
				ArtistEntity DevonPortielje = new ArtistEntity()
				{
					Id = 0,
					Name = "Devon Portielje"
				};

				ArtistEntity ConnerMolander = new ArtistEntity()
				{
					Id = 1,
					Name = "Conner Molander"
				};

				ArtistEntity DylanPhillips = new ArtistEntity()
				{
					Id = 2,
					Name = "Dylan Phillips"
				};

				ArtistEntity IsaacSymonds = new ArtistEntity()
				{
					Id = 3,
					Name = "Isaac Symonds"
				};

				ArtistEntity TylerJoseph = new ArtistEntity()
				{
					Id = 4,
					Name = "Tyler Joseph"
				};

				ArtistEntity JoshDun = new ArtistEntity()
				{
					Id = 5,
					Name = "Josh Dun"
				};

				TrackEntity ThenAgain = new TrackEntity()
				{
					Id = 0,
					Name = "Then Again",
					Length = 199,
					ReleaseDate = new DateTime(2019, 11, 1)
				};

				TrackEntity FavouriteBoy = new TrackEntity()
				{
					Id = 1,
					Name = "Favourite Boy",
					Length = 242,
					ReleaseDate = new DateTime(2019, 11, 1)
				};

				TrackEntity Jumpsuit = new TrackEntity()
				{
					Id = 2,
					Name = "Jumpsuit",
					Length = 239,
					ReleaseDate = new DateTime(2018, 10, 5)
				};

				TrackEntity Levitate = new TrackEntity()
				{
					Id = 3,
					Name = "Levitate",
					Length = 146,
					ReleaseDate = new DateTime(2018, 10, 5)
				};

				TrackEntity Morph = new TrackEntity()
				{
					Id = 4,
					Name = "Morph",
					Length = 259,
					ReleaseDate = new DateTime(2018, 10, 5)
				};

				AlbumEntity ABlemishInTheGreatLight = new AlbumEntity()
				{
					Id = 0,
					Name = "A Blemish in the Great Light",
					TrackEntities = new List<TrackEntity>() { ThenAgain, FavouriteBoy }
				};

				AlbumEntity Trench = new AlbumEntity()
				{
					Id = 1,
					Name = "Trench",
					TrackEntities = new List<TrackEntity>() { Jumpsuit, Levitate, Morph }
				};

				BandEntity HalfMoonRun = new BandEntity()
				{
					Id = 0,
					Name = "Half Moon Run",
					AlbumEntities = new List<AlbumEntity>() { ABlemishInTheGreatLight },
					ArtistEntities = new List<ArtistEntity>() { DevonPortielje, ConnerMolander, DylanPhillips, IsaacSymonds }
				};

				BandEntity TwentyOnePilots = new BandEntity()
				{
					Id = 1,
					Name = "twenty one pilots",
					AlbumEntities = new List<AlbumEntity>() { Trench },
					ArtistEntities = new List<ArtistEntity>() { TylerJoseph, JoshDun }
				};

				context.TrackContextEntities.Add(ThenAgain);
				context.TrackContextEntities.Add(FavouriteBoy);
				context.TrackContextEntities.Add(Jumpsuit);
				context.TrackContextEntities.Add(Levitate);
				context.TrackContextEntities.Add(Morph);
				context.AlbumContextEntities.Add(ABlemishInTheGreatLight);
				context.AlbumContextEntities.Add(Trench);
				context.ArtistContextEntities.Add(DevonPortielje);
				context.ArtistContextEntities.Add(ConnerMolander);
				context.ArtistContextEntities.Add(DylanPhillips);
				context.ArtistContextEntities.Add(IsaacSymonds);
				context.ArtistContextEntities.Add(TylerJoseph);
				context.ArtistContextEntities.Add(JoshDun);
				context.BandContextEntities.Add(HalfMoonRun);
				context.BandContextEntities.Add(TwentyOnePilots);
				//context.SaveChanges();
			}
		//}
	}
}
