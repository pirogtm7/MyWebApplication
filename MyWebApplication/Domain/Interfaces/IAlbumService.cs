using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebApplication.Domain.Models;

namespace MyWebApplication.Domain.Interfaces
{
	public interface IAlbumService
	{
		int CountAlbumLength(AlbumModel album);
	}
}
