using MovieStore.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MovieStore.Application.Models.ViewModels.DirectorViewModels
{
    public class DirectorVM
    {
        public int? Id { get; set; }

        [Display(Name = "Birth Date")]
        public string? BirthDate { get; set; }

        [Display(Name = "Statu")]
        public Status Statu { get; set; }

        [Display(Name = "Name")]
        public string FullName { get; set; }
    }
}
