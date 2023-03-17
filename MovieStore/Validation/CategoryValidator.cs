using FluentValidation;
using MovieStore.Models.ViewModels;

namespace MovieStore.Validation
{
    public class CategoryValidator : AbstractValidator<CategoryVM>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Name must be maximum 30 characters.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty.");
            RuleFor(x => x.Description).MaximumLength(250).WithMessage("Description must be maximum 250 characters.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description cannot be empty.");
        }
    }
}
