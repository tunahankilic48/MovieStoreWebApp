using MovieStore.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace MovieStore.Models.ViewModels
{
    public class LanguageVM
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Language name canot not be null.")]
        [MaxLength(20, ErrorMessage ="Language name can be maximum 20 characters")]
        [Display(Name ="Name")]
        public string? Name { get; set; }

    }
}
