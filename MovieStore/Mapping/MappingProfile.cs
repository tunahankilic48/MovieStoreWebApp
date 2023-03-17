using AutoMapper;
using MovieStore.Models.Entities;
using MovieStore.Models.ViewModels;

namespace MovieStore.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Director, DirectorVM>().ReverseMap();
            CreateMap<Starring, StarringVM>().ReverseMap();
            CreateMap<Category, CategoryVM>().ReverseMap();
            
        }
    }
}
