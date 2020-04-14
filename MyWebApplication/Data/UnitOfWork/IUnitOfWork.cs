using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebApplication.Data.Repositories;
using MyWebApplication.Data.Entities;

namespace MyWebApplication.Data.UnitOfWork
{
	public interface IUnitOfWork
	{
		IRepository<AlbumEntity> AlbumRepository { get; }
		IRepository<ArtistEntity> ArtistRepository { get; }
		IRepository<BandEntity> BandRepository { get; }
		IRepository<TrackEntity> TrackRepository { get; }
		//void Save();
	}
}
