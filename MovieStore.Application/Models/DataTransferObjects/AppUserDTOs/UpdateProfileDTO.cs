using Bogus.DataSets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using MovieStore.Application.Extensions;
using MovieStore.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MovieStore.Application.Models.DataTransferObjects.AppUserDTOs
{
    public class UpdateProfileDTO
    {
        //ToDo: password annotation için validator yazılacak
        //ToDo: Email validasyonu için validator eklenecek
        public string Id { get; set; }

        [Display(Name = "User Name")]
        [MinLength(4, ErrorMessage = "User name must be more than 4 characters.")]
        [MaxLength(20, ErrorMessage = "User name must be less than 20 characters.")]
        public string? UserName { get; set; }


        [Display(Name = "Password")]
        [MinLength(4, ErrorMessage = "Password must be more than 4 characters.")]
        [MaxLength(20, ErrorMessage = "Password must be less than 20 characters.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords are not same.")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }


        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [ValidateNever]
        public string? ImagePath{ get; set; }
        [PictureFileExtensionAttribute]
        public IFormFile? UploadPath{ get; set; }
        public Status Statu => Status.Modified;
    }
}
