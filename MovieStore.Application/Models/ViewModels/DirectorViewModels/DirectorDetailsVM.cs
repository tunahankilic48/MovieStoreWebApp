using MovieStore.Application.Models.ViewModels.MovieViewModels;
using MovieStore.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MovieStore.Application.Models.ViewModels.DirectorViewModels
{
    public class DirectorDetailsVM
    {
        public int? Id { get; set; }

        [Display(Name = "Birth Date")]
        public string? BirthDate { get; set; }

        [Display(Name = "Statu")]
        public Status Statu { get; set; }

        [Display(Name = "Name")]
        public string FullName { get; set; }

        public List<MovieVM>? DirectedMovies { get; set; }
    }
}
