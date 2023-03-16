
using MovieStore.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace MovieStore.Models.ViewModels
{
    public class DirectorVM
    {
        public int? Id { get; set; }

        [Required(ErrorMessage ="First name cannot be null.")]
        [MaxLength(20, ErrorMessage ="The maximum length of first name can be 20 characters")]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last name cannot be null.")]
        [MaxLength(20, ErrorMessage = "The maximum length of last name can be 30 characters")]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public DateTime? BirthDate { get; set; }
        [Display(Name = "Directed Movies")]
        public List<Movie>? DirectedMovies { get; set; }
    }
}
