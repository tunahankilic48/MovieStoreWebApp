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
    public class MovieVM
    {
        [Display(Name = "ID")]
        public int? Id { get; set; }
        [Display(Name = "Name")]
        public string? Name { get; set; }
        [Display(Name = "Description")]
        public string? Description { get; set; }
        [Display(Name = "Image")]
        public string? ImagePath { get; set; }
        [Display(Name = "Director")]
        public string? DirectorName { get; set; }
        [Display(Name = "Category")]
        public string? CategoryName { get; set; }
        [Display(Name = "Price")]
        public decimal? Price { get; set; }
        public Category? Category { get; set; }
        public Director? Director { get; set; }
    }
}
