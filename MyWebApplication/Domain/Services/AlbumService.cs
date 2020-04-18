using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebApplication.Domain.Models;
using MyWebApplication.Domain.Interfaces;
using MyWebApplication.Data.Repositories;
using MyWebApplication.Data.Entities;
using MyWebApplication.Data;
using MyWebApplication.Data.UnitOfWork;
using AutoMapper;


namespace MyWebApplication.Domain.Services
{
	public class AlbumService : IAlbumService
	{
		private readonly IUnitOfWork UnitOfWork;
		IMapper mapper;
		ITrackService TrackService;

		public AlbumService(IUnitOfWork unitOfWork, IMapper mapper, 
			ITrackService trackService)
		{
			UnitOfWork = unitOfWork;
			this.mapper = mapper;
			TrackService = trackService;
		}

		public AlbumModel GetAlbum(int id)
		{
			var album = UnitOfWork.AlbumRepository.Get(id);
			var albumModel = mapper.Map<AlbumModel>(album);
			return albumModel;
		}

		public IEnumerable<AlbumModel> GetAlbumsFromBand(BandModel band)
		{
			var albumsFromBand = new List<AlbumEntity>();
			foreach (AlbumEntity album in UnitOfWork.AlbumRepository.GetAll())
			{
				if (album.BandEntityId == band.Id)
				{
					albumsFromBand.Add(album);
				}
			}
			var albumModels = mapper.Map<IEnumerable<AlbumModel>>(albumsFromBand);
			return albumModels;
		}

		public int CountAlbumLength(AlbumModel album)
		{
			int AlbumLength = 0;
			foreach (TrackModel track in TrackService.GetTracksFromAlbum(album))
			{
				AlbumLength += track.Length;
			}
			return AlbumLength;
		}
	}
}
