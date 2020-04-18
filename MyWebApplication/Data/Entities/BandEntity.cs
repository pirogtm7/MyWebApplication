using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApplication.Data.Entities
{
	public class BandEntity : BaseEntity
	{
		public string Name { get; set; }
		public List<ArtistEntity> ArtistEntities { get; set; }
		public List<AlbumEntity> AlbumEntities { get; set; }

		public BandEntity()
		{
			ArtistEntities = new List<ArtistEntity>();
			AlbumEntities = new List<AlbumEntity>();
		}
	}
}
