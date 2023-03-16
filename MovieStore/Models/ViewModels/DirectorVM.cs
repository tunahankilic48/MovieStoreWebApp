
using MovieStore.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace MovieStore.Models.ViewModels
{
    public class DirectorVM
    {
        public int? Id { get; set; }

        [Required(ErrorMessage ="First name cannot be null.")]
        [MaxLength(20, ErrorMessage ="The maximum length of first name can be 20 characters")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last name cannot be null.")]
        [MaxLength(20, ErrorMessage = "The maximum length of last name can be 30 characters")]
        public string? LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
        public List<Movie>? DirectedMovies { get; set; }
    }
}
