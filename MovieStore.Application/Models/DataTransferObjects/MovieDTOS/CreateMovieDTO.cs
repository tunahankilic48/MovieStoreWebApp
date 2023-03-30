using Microsoft.AspNetCore.Http;
using MovieStore.Application.Models.ViewModels.CategoryViewModels;
using MovieStore.Application.Models.ViewModels.DirectorViewModels;
using MovieStore.Application.Models.ViewModels.LanguageViewModels;
using MovieStore.Application.Models.ViewModels.StarringViewModels;
using MovieStore.Domain.Entities;
using MovieStore.Domain.Enums;

namespace MovieStore.Application.Models.DataTransferObjects.MovieDTOS
{
    internal class CreateMovieDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
        public int? DirectorId { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? RunningTimeMin { get; set; }

        public int? LanguageId { get; set; }
        public decimal? Price { get; set; }
        public int? Stock { get; set; }
        public bool IsActive { get; set; }
        public IFormFile? Image { get; set; }
        public string? ImagePath { get; set; }
        public List<int> AddStarringsIds { get; set; }
        public List<int> DeleteStarringsIds { get; set; }
        public Status Statu => Status.Active;

        public List<CategoryVM>? Categories { get; set; }
        public List<DirectorVM>? Directors { get; set; }
        public List<LanguageVM>? Languages { get; set; }



        public List<Starring>? StarringsThatRoleInMovie { get; set; }
        public List<StarringVM>? Starrings { get; set; }
    }
}
