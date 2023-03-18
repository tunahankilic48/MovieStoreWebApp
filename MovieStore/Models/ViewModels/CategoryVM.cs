using MovieStore.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace MovieStore.Models.ViewModels
{
    public class CategoryVM
    {
        public CategoryVM()
        {
            Movies = new List<Movie>();
        }
        public int? Id { get; set; }

        [Display(Name="Name")]
        public string? Name { get; set; }

        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Display(Name="Movies in Category")]
        public List<Movie>? Movies { get; set; }
    }
}
