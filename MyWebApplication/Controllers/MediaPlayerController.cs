using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApplication.Data.Repositories;
using MyWebApplication.Data.Entities;
using MyWebApplication.Domain.Interfaces;
using MyWebApplication.Data;
using MyWebApplication.Domain.Models;
using AutoMapper;

namespace MyWebApplication.Controllers
{
    public class MediaPlayerController : Controller
    {
        IBandService BandService;
        IAlbumService AlbumService;
        ITrackService TrackService;

        public MediaPlayerController(IBandService bandService, IAlbumService albumService,
            ITrackService trackService)
        {
            BandService = bandService;
            AlbumService = albumService;
            TrackService = trackService;
        }

        public ActionResult Index()
        {
            return View(BandService.GetAllBands());
        }

        [HttpGet]
        public ActionResult AlbumsFromBand(int id)
        {
            var band = BandService.GetBand(id);
            ViewBag.Band = band;
            ViewBag.Albums = AlbumService.GetAlbumsFromBand(band);
            return View();
        }

        [HttpGet]
        public ActionResult SongsFromAlbum(int idAlbum, int idBand)
        {
            var band = BandService.GetBand(idBand);
            ViewBag.Band = band;
            var album = AlbumService.GetAlbum(idAlbum);
            ViewBag.Album = album;
            ViewBag.Tracks = TrackService.GetTracksFromAlbum(album);
            return View();
        }

        [HttpGet]
        public ActionResult AddSongToAlbum(int idBand, int idAlbum)
        {
            ViewBag.Band = BandService.GetBand(idBand);
            ViewBag.Album = AlbumService.GetAlbum(idAlbum);
            return View();
        }

        [HttpPost]
        public ActionResult AddSongToAlbum(int idBand, int idAlbum, TrackModel track)
        {
            try
            {
                track.AlbumEntityId = idAlbum;
                ViewBag.Band = BandService.GetBand(idBand);
                var album = AlbumService.GetAlbum(idAlbum);
                //track.AlbumEntity = album;
                ViewBag.Album = album;
                TrackService.AddTrackToAlbum(track);
                return RedirectToAction(nameof(SongsFromAlbum), new { idAlbum = idAlbum, idBand = ViewBag.Band.Id});
            }
            catch
            {
                return View(track);
            }
        }

        [HttpGet]
        public ActionResult EditSong(int idBand, int idAlbum, int idTrack)
        {
            ViewBag.Band = BandService.GetBand(idBand);
            ViewBag.Album = AlbumService.GetAlbum(idAlbum);
            ViewBag.Track = TrackService.GetTrack(idTrack);
            return View();
        }

        [HttpPost]
        public ActionResult EditSong(int idBand, int idAlbum, int idTrack, TrackModel track)
        {
            try
            {
                track.Id = idTrack;
                track.AlbumEntityId = idAlbum;
                ViewBag.Band = BandService.GetBand(idBand);
                var album = AlbumService.GetAlbum(idAlbum);
                ViewBag.Album = album;
                TrackService.EditTrack(track);
                return RedirectToAction(nameof(SongsFromAlbum), new { idAlbum = idAlbum, idBand = ViewBag.Band.Id });
            }
            catch
            {
                return View(track);
            }
        }

        [HttpGet]
        public ActionResult DeleteSongFromAlbum(int idBand, int idAlbum, int idTrack)
        {
            ViewBag.Band = BandService.GetBand(idBand);
            ViewBag.Album = AlbumService.GetAlbum(idAlbum);
            var track = TrackService.GetTrack(idTrack);
            ViewBag.Track = track;

            return View(track);
        }

        [HttpPost, ActionName("DeleteSongFromAlbum")]
        public ActionResult DeleteSongConfirmation(int idBand, int idAlbum, int idTrack)
        {

            ViewBag.Band = BandService.GetBand(idBand);
            var album = AlbumService.GetAlbum(idAlbum);
            ViewBag.Album = album;
            var track = TrackService.GetTrack(idTrack);
            ViewBag.Track = track;
            TrackService.DeleteTrackFromAlbum(track);

            return RedirectToAction(nameof(SongsFromAlbum), new { idAlbum = idAlbum, idBand = ViewBag.Band.Id });
        }

        [HttpGet]
        public ActionResult CountAlbumLength(int idAlbum, int idBand)
        {
            ViewBag.Band = BandService.GetBand(idBand);
            var album = AlbumService.GetAlbum(idAlbum);
            ViewBag.Album = album;
            ViewBag.AlbumLength = AlbumService.CountAlbumLength(album);
            return View();
        }
    }
}