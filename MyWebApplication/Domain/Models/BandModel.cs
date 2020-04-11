using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApplication.Domain.Models
{
	public class BandModel : BaseModel
	{
		public string Name { get; set; }
		public List<ArtistModel> ArtistModels { get; set; }
		public List<AlbumModel> AlbumModels { get; set; }
	}
}
