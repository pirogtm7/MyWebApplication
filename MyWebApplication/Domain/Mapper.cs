using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebApplication.Domain.Models;
using MyWebApplication.Data.Entities;

namespace MyWebApplication.Domain
{
	public class Mapper : Profile
	{
        public Mapper()
        {
            CreateMap<AlbumEntity, AlbumModel>().ReverseMap();
            CreateMap<ArtistEntity, ArtistModel>().ReverseMap();
            CreateMap<BandEntity, BandModel>().ReverseMap();
            CreateMap<TrackEntity, TrackModel>().ReverseMap();
        }
    }
}
