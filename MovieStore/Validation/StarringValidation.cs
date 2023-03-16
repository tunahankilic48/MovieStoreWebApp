using FluentValidation;
using MovieStore.Models.ViewModels;

namespace MovieStore.Validation
{
    public class StarringValidation : AbstractValidator<StarringVM>
    {
        public StarringValidation()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name cannot be null.")
                                     .MaximumLength(20).WithMessage("The maximum length of first name can be 20 characters");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name cannot be null.")
                                     .MaximumLength(30).WithMessage("The maximum length of last name can be 30 characters");                         
        }
    }
}
