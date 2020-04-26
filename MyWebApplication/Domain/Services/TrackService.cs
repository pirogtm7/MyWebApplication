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

		public void AddTrackToAlbum(TrackModel track)
		{
			var newtrack = mapper.Map<TrackEntity>(track);
			UnitOfWork.TrackRepository.Add(newtrack);
			UnitOfWork.Save();
		}
		
		public void EditTrack(TrackModel track)
		{
			foreach(TrackEntity oldtrack in UnitOfWork.TrackRepository.GetAll())
			{
				if (oldtrack.Id == track.Id)
				{
					oldtrack.Name = track.Name;
					oldtrack.Length = track.Length;
					oldtrack.ReleaseDate = track.ReleaseDate;
					UnitOfWork.TrackRepository.Update(oldtrack);
					UnitOfWork.Save();
					break;
				}
			}
		}

		public void DeleteTrackFromAlbum(TrackModel track)
		{
			UnitOfWork.TrackRepository.Delete(track.Id);
			UnitOfWork.Save();
		}

		public IEnumerable<TrackModel> GetTracksFromAlbum(AlbumModel album)
		{
			var tracksFromAlbum = new List<TrackEntity>();
			foreach (TrackEntity track in UnitOfWork.TrackRepository.GetAll())
			{
				if (track.AlbumEntityId == album.Id)
				{
					tracksFromAlbum.Add(track);
				}
			}
			var trackModels = mapper.Map<IEnumerable<TrackModel>>(tracksFromAlbum);
			return trackModels;
		}

		public IEnumerable<TrackModel> GetAllTracks()
		{
			var tracks = UnitOfWork.TrackRepository.GetAll();
			var trackModels = mapper.Map<IEnumerable<TrackModel>>(tracks);
			return trackModels;
		}
	}
}
