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
	public class ArtistService : IArtistService
	{
		UnitOfWork UnitOfWork;
		IMapper mapper;

		public ArtistService(UnitOfWork unitOfWork, IMapper mapper)
		{
			UnitOfWork = unitOfWork;
			this.mapper = mapper;
		}

		//public void AddArtist(ArtistModel artist, BandModel band)
		//{
		//	if (artist != null)
		//	{
		//		band.ArtistModels.Add(artist);
		//	}

		//}

	}
}
