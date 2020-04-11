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
        private IRepository<AlbumEntity> AlbumRepos;
        private IAlbumService AlbumService;
        IMapper mapper;

        public MediaPlayerController(MediaPlayerContext context, IMapper mapper, IAlbumService alServ)
        {
            AlbumRepos = new Repository<AlbumEntity>(context);
            this.mapper = mapper;
            AlbumService = alServ;
        }

        public ActionResult Index()
        {
            return View(AlbumRepos.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AlbumEntity album)
        {
            try
            {
                AlbumRepos.Add(album);
                AlbumRepos.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(album);
            }
        }

        public ActionResult Edit(int id)
        {
            AlbumEntity album = AlbumRepos.Get(id);
            return View(album);
        }

        [HttpPost]
        public ActionResult Edit(AlbumEntity album)
        {
            try
            {
                AlbumRepos.Update(album);
                AlbumRepos.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(album);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            AlbumEntity album = AlbumRepos.Get(id);
            return View(album);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmation(int id)
        {
            try
            {
                AlbumRepos.Delete(id);
                AlbumRepos.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult CountAlbumLength(int id)
        {
            AlbumEntity album = AlbumRepos.Get(id);
            AlbumModel albumModel = mapper.Map<AlbumModel>(album);
            return View(AlbumService.CountAlbumLength(albumModel));
        }
    }
}