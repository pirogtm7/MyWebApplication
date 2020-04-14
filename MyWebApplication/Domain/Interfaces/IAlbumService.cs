using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebApplication.Domain.Models;

namespace MyWebApplication.Domain.Interfaces
{
	public interface IAlbumService
	{
		IEnumerable<AlbumModel> GetAlbumsFromBand(BandModel band);
		int CountAlbumLength(AlbumModel album);
		AlbumModel GetAlbum(int id);
		AlbumModel GetAlbumFromBand(BandModel band, int idAlbum);
	}
}
