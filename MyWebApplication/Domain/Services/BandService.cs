using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebApplication.Domain.Models;
using MyWebApplication.Domain.Interfaces;
using MyWebApplication.Data.UnitOfWork;
using AutoMapper;

namespace MyWebApplication.Domain.Services
{
	public class BandService : IBandService
	{
		readonly IUnitOfWork UnitOfWork;
		IMapper mapper;

		public BandService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			UnitOfWork = unitOfWork;
			this.mapper = mapper;
		}

		public BandModel GetBand(int id)
		{
			var band = UnitOfWork.BandRepository.Get(id);
			var bandModel = mapper.Map<BandModel>(band);
			return bandModel;
		}

		public IEnumerable<BandModel> GetAllBands()
		{
			var bands = UnitOfWork.BandRepository.GetAll();
			var bandModels = mapper.Map<IEnumerable<BandModel>>(bands);
			return bandModels;
		}
	}
}
