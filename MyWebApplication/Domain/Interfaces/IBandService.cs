using MyWebApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApplication.Domain.Interfaces
{
	public interface IBandService
	{
		BandModel GetBand(int id);
		IEnumerable<BandModel> GetAllBands();
	}
}
