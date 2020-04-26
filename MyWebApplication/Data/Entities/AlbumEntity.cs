using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApplication.Data.Entities
{
	public class AlbumEntity : BaseEntity
	{
		public string Name { get; set; }
		public List<TrackEntity> TrackEntities { get; set; }
		public int BandEntityId { get; set; }
		//public BandEntity BandEntity { get; set; }

		public AlbumEntity()
		{
			TrackEntities = new List<TrackEntity>();
		}

	}
}
