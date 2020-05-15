using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApplication.Domain.ViewModels
{
	public class SearchViewModel
	{
		//[DataType(DataType.DateTime)]
		public DateTime ReleaseDate { get; set; }
		public string BandName { get; set; }
		public string TrackName { get; set; }
	}
}
