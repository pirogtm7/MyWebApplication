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
            CreateMap<AlbumModel, AlbumEntity>()
                .ForMember(d => d.TrackEntities, opt => opt.MapFrom(src => src.TrackModels))
                .ReverseMap();
            CreateMap<ArtistModel, ArtistEntity>()
                .ReverseMap();
            CreateMap<BandModel, BandEntity>()
                .ForMember(d => d.AlbumEntities, opt => opt.MapFrom(src => src.AlbumModels))
                .ForMember(d => d.ArtistEntities, opt => opt.MapFrom(src => src.ArtistModels))
                .ReverseMap();
            CreateMap<TrackModel, TrackEntity>()
                .ReverseMap();
        }
    }
}
