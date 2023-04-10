using MovieStore.Application.Models.ViewModels.MovieViewModels;
using MovieStore.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MovieStore.Application.Models.DataTransferObjects.DirectorDTOs
{
    public class UpdateDirectorDTO
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "First name cannot be null.")]
        [MaxLength(20, ErrorMessage = "The maximum length of first name can be 20 characters")]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last name cannot be null.")]
        [MaxLength(30, ErrorMessage = "The maximum length of last name can be 30 characters")]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public DateTime? BirthDate { get; set; }


        public Status Statu { get; set; }

        [Display(Name = "Directed Movies")]

        public List<MovieVM>? DirectedMovies { get; set; }

    }
}
