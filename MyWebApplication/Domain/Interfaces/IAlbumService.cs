using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebApplication.Domain.Models;
using MyWebApplication.Domain.ViewModels;

namespace MyWebApplication.Domain.Interfaces
{
	public interface IAlbumService
	{
		IEnumerable<AlbumModel> GetAlbumsFromBand(BandModel band);
		int CountAlbumLength(AlbumModel album);
		AlbumModel GetAlbum(int id);
		IEnumerable<AlbumModel> GetAllAlbums();
		IEnumerable<AlbumModel> AlbumSearch(SearchViewModel search);
	}
}
