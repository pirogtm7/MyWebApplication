using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApplication.Data.Entities
{
	public class TrackEntity : BaseEntity
	{
		public string Name { get; set; }
		public int Length { get; set; }
		public DateTime ReleaseDate { get; set; }
		public int AlbumEntityId { get; set; }
		public AlbumEntity AlbumEntity { get; set; }
	}
}
