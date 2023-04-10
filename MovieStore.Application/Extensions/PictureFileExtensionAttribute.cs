using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MovieStore.Application.Extensions
{
    internal class PictureFileExtensionAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            IFormFile file = (IFormFile)value;

            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName).ToLower();
                string[] extensions = { ".jpg", ".jpeg", ".png" };

                bool result = extensions.Any(x => x.EndsWith(extension));

                if (!result)
                {
                    return new ValidationResult("Valid format is 'jpg', 'jpeg', 'png'");
                }
            }


            return ValidationResult.Success;
        }


    }
}
