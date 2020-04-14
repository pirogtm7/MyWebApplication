using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebApplication.Data.Repositories;
using MyWebApplication.Data.Entities;

namespace MyWebApplication.Data.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly MediaPlayerContext context;
		public IRepository<AlbumEntity> AlbumRepository { get; }
		public IRepository<ArtistEntity> ArtistRepository { get; }
		public IRepository<BandEntity> BandRepository { get; }
		public IRepository<TrackEntity> TrackRepository { get; }

		public UnitOfWork(MediaPlayerContext context, IRepository<AlbumEntity> albums,
			IRepository<ArtistEntity> artists, IRepository<BandEntity> bands,
			IRepository<TrackEntity> tracks)
		{
			this.context = context;
			AlbumRepository = albums;
			ArtistRepository = artists;
			BandRepository = bands;
			TrackRepository = tracks;
		}

		//public void Save()
		//{
		//	context.SaveChanges();
		//}
	}
}
