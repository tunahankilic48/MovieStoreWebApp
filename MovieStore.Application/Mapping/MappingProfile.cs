using AutoMapper;
using MovieStore.Application.Models.DataTransferObjects.AppUserDTOs;
using MovieStore.Application.Models.DataTransferObjects.CategoryDTOs;
using MovieStore.Application.Models.DataTransferObjects.LanguageDTOs;
using MovieStore.Application.Models.DataTransferObjects.MovieDTOS;
using MovieStore.Application.Models.DataTransferObjects.StarringDTOs;
using MovieStore.Application.Models.ViewModels.CategoryViewModels;
using MovieStore.Application.Models.ViewModels.DirectorViewModels;
using MovieStore.Application.Models.ViewModels.LanguageViewModels;
using MovieStore.Application.Models.ViewModels.MovieViewModels;
using MovieStore.Application.Models.ViewModels.StarringViewModels;
using MovieStore.Domain.Entities;

namespace MovieStore.Application.Mapping
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, RegistorDTO>().ReverseMap();

            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
            CreateMap<Category, CategoryVM>().ReverseMap(); 
            
            CreateMap<Language, CreateLanguageDTO>().ReverseMap();
            CreateMap<Language, UpdateLanguageDTO>().ReverseMap();
            CreateMap<Language, LanguageVM>().ReverseMap();

            CreateMap<Director, CreateCategoryDTO>().ReverseMap();
            CreateMap<Director, UpdateCategoryDTO>().ReverseMap();
            CreateMap<Director, DirectorVM>().ReverseMap();
            CreateMap<Director, DirectorDetailsVM>().ReverseMap(); 
            
            CreateMap<Starring, CreateStarringDTO>().ReverseMap();
            CreateMap<Starring, UpdateStarringDTO>().ReverseMap();
            CreateMap<Starring, StarringVM>().ReverseMap();
            CreateMap<Starring, StarringDetailsVM>().ReverseMap();
            
            CreateMap<Movie, CreateMovieDTO>().ReverseMap();
            CreateMap<Movie, UpdateMovieDTO>().ReverseMap();
            CreateMap<Movie, MovieVM>().ReverseMap();
            CreateMap<Movie, MovieDetailsVM>().ReverseMap();
        }
    }
}
