using Microsoft.AspNetCore.Http;
using MovieStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MovieStore.Application.Models.ViewModels.MovieViewModels
{
    public class MovieDetailsVM
    {
        [Display(Name = "ID")]
        public int? Id { get; set; }
        [Display(Name = "Name")]
        public string? Name { get; set; }
        [Display(Name = "Description")]
        public string? Description { get; set; }
        [Display(Name = "Category")]
        public string? CategoryName { get; set; }
        [Display(Name = "Director")]
        public string? DirectorName { get; set; }
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }
        [Display(Name = "Runnin Time (min)")]
        public int? RunningTimeMin { get; set; }
        [Display(Name = "Language")]
        public string? LanguageName { get; set; }
        [Display(Name = "Price")]
        public decimal? Price { get; set; }
        [Display(Name = "Stock")]
        public int? Stock { get; set; }
        [Display(Name = "In Sale")]
        public bool? IsActive { get; set; }


        public IFormFile? Image { get; set; }

        public string? ImagePath { get; set; }




        public List<int> AddStarringsIds { get; set; }



        public List<int> DeleteStarringsIds { get; set; }

        public Category? Category { get; set; }
        public Director? Director { get; set; }
        public Language? Language { get; set; }



        public List<Starring>? Starrings { get; set; }
    }
}
