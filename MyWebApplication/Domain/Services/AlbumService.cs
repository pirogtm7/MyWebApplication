using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebApplication.Domain.Models;
using MyWebApplication.Domain.ViewModels;
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
		IBandService BandService;

		public AlbumService(IUnitOfWork unitOfWork, IMapper mapper, 
			ITrackService trackService, IBandService bandService)
		{
			UnitOfWork = unitOfWork;
			this.mapper = mapper;
			TrackService = trackService;
			BandService = bandService;
		}

		public AlbumModel GetAlbum(int id)
		{
			var album = UnitOfWork.AlbumRepository.Get(id);
			var albumModel = mapper.Map<AlbumModel>(album);
			return albumModel;
		}

		public IEnumerable<AlbumModel> GetAllAlbums()
		{
			var albums = UnitOfWork.AlbumRepository.GetAll();
			var albumsModel = mapper.Map<IEnumerable<AlbumModel>>(albums);
			return albumsModel;
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

		public IEnumerable<AlbumModel> AlbumSearch(SearchViewModel search)
		{
			var foundAlbums = GetAllAlbums().ToList();

			for (int i = foundAlbums.Count-1; i >= 0; i--)
			{
				if (!string.IsNullOrEmpty(search.BandName))
				{
					var band = BandService.GetBand(foundAlbums[i].BandEntityId);

					if (band.Name != search.BandName)
					{
						foundAlbums.RemoveAt(i);
						goto link;
					}
				}

				if (!string.IsNullOrEmpty(search.TrackName))
				{
					int coincCountTrack = 0;

					foreach (TrackModel track in TrackService.GetTracksFromAlbum(foundAlbums[i]))
					{
						if (track.Name == search.TrackName)
						{
							coincCountTrack++;
						}
					}

					if (coincCountTrack < 1)
					{
						foundAlbums.RemoveAt(i);
						goto link;
					}
				}

				int coincCountRD = 0;

				foreach (TrackModel track in TrackService.GetTracksFromAlbum(foundAlbums[i]))
				{
					if (track.ReleaseDate == search.ReleaseDate)
					{
						coincCountRD++;
					}
				}

				if (coincCountRD < 1)
				{
					foundAlbums.RemoveAt(i);
				}
			link:
				Console.WriteLine("");
			}

			return foundAlbums;
		}

		//	public IEnumerable<AlbumModel> AlbumSearch(SearchViewModel search)
		//	{
		//		List<AlbumModel> foundAlbums = new List<AlbumModel>();

		//		foreach (var album in GetAllAlbums())
		//		{
		//			 foundAlbums = GetAllAlbums().ToList();

		//			if (search.BandName != "")
		//			{
		//				var band = BandService.GetBand(album.BandEntityId);
		//				foundAlbums.RemoveAll(al => band.Name != search.BandName);
		//			}

		//			if (search.TrackName != "")
		//			{
		//				foreach (TrackModel track in album.TrackModels)
		//				{
		//					foundAlbums.RemoveAll(al => track.Name != search.TrackName);
		//				}
		//			}

		//			if (search.ReleaseDate != new DateTime(2000, 01, 01))
		//			{
		//				foreach (TrackModel track in album.TrackModels)
		//				{
		//					foundAlbums.RemoveAll(al => track.ReleaseDate != search.ReleaseDate);
		//				}
		//			}
		//		}

		//		return foundAlbums;
		//	}
	}
}
