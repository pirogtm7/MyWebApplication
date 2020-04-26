using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebApplication.Domain.Models;

namespace MyWebApplication.Domain.Interfaces
{
	public interface ITrackService
	{
		TrackModel GetTrack(int id);
		IEnumerable<TrackModel> GetTracksFromAlbum(AlbumModel album);
		void AddTrackToAlbum(TrackModel track);
		void DeleteTrackFromAlbum(TrackModel track);
		void EditTrack(TrackModel track);
		IEnumerable<TrackModel> GetAllTracks();
	}
}
