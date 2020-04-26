using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApplication.Domain.Interfaces;
using MyWebApplication.Domain.Models;

namespace MyApiApplication.Controllers
{
    [Route("api/Song")]
    [ApiController]
    public class SongController : ControllerBase
    {
        ITrackService TrackService;

        public SongController(ITrackService trackService)
        {
            TrackService = trackService;
        }

        [HttpGet]
        public IEnumerable<TrackModel> GetTracks()
        {
            return TrackService.GetAllTracks();
        }

        [HttpGet("{id}", Name = "GetTrack")]
        public ActionResult GetTrack(int id)
        {
            var track = TrackService.GetTrack(id);
            if (track == null)
            {
                return BadRequest();
            }
            return Ok(track);
        }

        [HttpPost]
        public ActionResult<TrackModel> AddTrack(TrackModel track)
        {
            TrackService.AddTrackToAlbum(track);
            return CreatedAtAction(nameof(GetTrack), new { id = track.Id }, track);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTrack(int id, TrackModel track)
        {
            if (id != track.Id)
            {
                return BadRequest();
            }
            TrackService.EditTrack(track);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTrack(int id)
        {
            TrackService.DeleteTrackFromAlbum(
                TrackService.GetTrack(id));
            return NoContent();
        }
    }
}