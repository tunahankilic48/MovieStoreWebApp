using MovieStore.Application.Models.ViewModels.MovieViewModels;
using MovieStore.Domain.Enums;

namespace MovieStore.Application.Models.ViewModels.DirectorViewModels
{
    internal class DirectorDetailsVM
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public Status Statu { get; set; }

        public List<MovieVM>? DirectedMovies { get; set; }
    }
}
