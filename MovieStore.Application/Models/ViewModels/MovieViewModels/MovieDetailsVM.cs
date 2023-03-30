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
    internal class MovieDetailsVM
    {
        public int? Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }
        public string? CategoryName { get; set; }

        public string? DirectorName { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public int? RunningTimeMin { get; set; }

        public string? LanguageName { get; set; }

        public decimal? Price { get; set; }

        public int? Stock { get; set; }



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
