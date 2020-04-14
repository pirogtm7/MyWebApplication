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
            CreateMap<AlbumEntity, AlbumModel>()
                .ForMember(d => d.TrackModels, opt => opt.MapFrom(src => src.TrackEntities))
                .ReverseMap();
            CreateMap<ArtistEntity, ArtistModel>().ReverseMap();
            CreateMap<BandEntity, BandModel>()
                .ForMember(d => d.AlbumModels, opt => opt.MapFrom(src => src.AlbumEntities))
                .ForMember(d => d.ArtistModels, opt => opt.MapFrom(src => src.ArtistEntities))
                .ReverseMap();
            CreateMap<TrackEntity, TrackModel>().ReverseMap();
        }
    }
}
