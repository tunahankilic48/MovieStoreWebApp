using System.ComponentModel.DataAnnotations;

namespace MovieStore.Application.Models.ViewModels.CategoryViewModels
{
    public class CategoryDetailsVM
    {
        [Display(Name = "ID")]
        public int? Id { get; set; }

        [Display(Name = "Name")]
        public string? Name { get; set; }

        [Display(Name = "Description")]
        public string? Description { get; set; }
    }
}
