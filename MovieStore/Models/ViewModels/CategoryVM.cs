using MovieStore.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace MovieStore.Models.ViewModels
{
    public class CategoryVM
    {
        public int? Id { get; set; }

        [Display(Name="Name")]
        public string? Name { get; set; }

        [Display(Name = "Name")]
        public string? Description { get; set; }

        [Display(Name="Movies in Category")]
        public List<Movie>? Movies { get; set; }
    }
}
