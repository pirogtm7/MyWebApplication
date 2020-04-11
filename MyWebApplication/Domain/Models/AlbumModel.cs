using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApplication.Domain.Models
{
	public class AlbumModel : BaseModel
	{
		public string Name { get; set; }
		public List<TrackModel> TrackModels { get; set; }
	}
}
