using Microsoft.AspNetCore.Http;
using MovieStore.Domain.Entities;
using MovieStore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Application.Models.DataTransferObjects.MovieDTOS
{
    internal class UpdateMovieDTO
    {
        public int? Id { get; set; }
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

        public Category? Category { get; set; }
        public Director? Director { get; set; }
        public Language? Language { get; set; }



        public List<Starring>? Starrings { get; set; }
    }
}
