using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebApplication.Domain.Models;
using MyWebApplication.Domain.Interfaces;

namespace MyWebApplication.Domain.Services
{
	public class AlbumService : IAlbumService
	{
		public int CountAlbumLength(AlbumModel album)
		{
			int AlbumLength = 0;
			foreach (TrackModel track in album.TrackModels)
			{
				AlbumLength += track.Length;
			}
			return AlbumLength;
		}
	}
}
