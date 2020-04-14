using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebApplication.Domain.Models;
using MyWebApplication.Domain.Interfaces;
using MyWebApplication.Data.UnitOfWork;
using MyWebApplication.Data.Entities;
using AutoMapper;

namespace MyWebApplication.Domain.Services
{
	public class TrackService : ITrackService
	{
		IUnitOfWork UnitOfWork;
		IMapper mapper;

		public TrackService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			UnitOfWork = unitOfWork;
			this.mapper = mapper;
		}

		public TrackModel GetTrack(int id)
		{
			var track = UnitOfWork.TrackRepository.Get(id);
			var trackModel = mapper.Map<TrackModel>(track);
			return trackModel;
		}

		public void AddTrackToAlbumAndToRepos(AlbumModel album, TrackModel track)
		{
			var newTrack = mapper.Map<TrackEntity>(track);
			UnitOfWork.TrackRepository.Add(newTrack);

			foreach (AlbumEntity albumEntity in UnitOfWork.AlbumRepository.GetAll())
			{
				if (albumEntity.Id == album.Id)
				{
					albumEntity.TrackEntities.Add(newTrack);
					break;
				}
			}
			//UnitOfWork.Save();
		}
		
		public void EditTrack(AlbumModel album, TrackModel track)
		{
			var oldTrack = UnitOfWork.TrackRepository.Get(track.Id);
			var newTrack = mapper.Map<TrackEntity>(track);
			UnitOfWork.TrackRepository.Update(oldTrack, newTrack);


			foreach (AlbumEntity albumEntity in UnitOfWork.AlbumRepository.GetAll())
			{
				if (albumEntity.Id == album.Id)
				{
					foreach (TrackEntity oldTrackEntity in albumEntity.TrackEntities)
					{
						if (oldTrackEntity.Id == newTrack.Id)
						{
							oldTrackEntity.Name = newTrack.Name;
							oldTrackEntity.Length = newTrack.Length;
							oldTrackEntity.ReleaseDate = newTrack.ReleaseDate;
							break;
						}
					}
				}
			}
		}

		public void DeleteTrackFromAlbumAndFromRepos(AlbumModel album, TrackModel track)
		{
			UnitOfWork.TrackRepository.Delete(track.Id);
			var deleteTrack = mapper.Map<TrackEntity>(track);

			foreach (AlbumEntity albumEntity in UnitOfWork.AlbumRepository.GetAll())
			{
				if (albumEntity.Id == album.Id)
				{
					foreach (TrackEntity trackEntity in albumEntity.TrackEntities)
					{
						if (trackEntity.Id == deleteTrack.Id)
						{
							albumEntity.TrackEntities.Remove(trackEntity);
							break;
						}
					}
				}
			}
			//UnitOfWork.Save();
		}

		public IEnumerable<TrackModel> GetTracksFromAlbum(AlbumModel album)
		{
			var tracksFromAlbum = new List<TrackEntity>();

			foreach (TrackEntity track in UnitOfWork.AlbumRepository.Get(album.Id).TrackEntities)
			{
				tracksFromAlbum.Add(track);
			}

			var tracksFromAlbumModels = mapper.Map<IEnumerable<TrackModel>>(tracksFromAlbum);
			return tracksFromAlbumModels;
		}

		public IEnumerable<TrackModel> GetAllTracks()
		{
			var tracks = UnitOfWork.TrackRepository.GetAll();
			var trackModels = mapper.Map<IEnumerable<TrackModel>>(tracks);
			return trackModels;
		}
	}
}
