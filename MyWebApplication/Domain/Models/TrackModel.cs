using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApplication.Domain.Models
{
	public class TrackModel : BaseModel
	{
		public string Name { get; set; }
		public int Length { get; set; }
		public DateTime ReleaseDate { get; set; }
		public int AlbumEntityId { get; set; }
		public AlbumModel AlbumEntity { get; set; }
	}
}
