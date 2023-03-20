using System;
using AutoMapper;
using MovieCatalogue.BLL.Models;
using MovieCatalogue.DAL.Entities;

namespace MovieCatalogue.BLL.MappingProfile
{
    
    
        public class MovieMappingProfile : Profile
        {
            public MovieMappingProfile()
            {
                CreateMap<AddorUpdateMovieVM, Movies>();
            // .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));
            CreateMap<Movies, MovieVM>();
        }
        }
    
}

