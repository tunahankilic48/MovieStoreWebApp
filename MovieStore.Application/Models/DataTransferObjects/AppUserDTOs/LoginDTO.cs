using Bogus.DataSets;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Application.Models.DataTransferObjects.AppUserDTOs
{
    public class LoginDTO
    {
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User name cannot be null")]
        [MinLength(4, ErrorMessage = "User name must be more than 4 characters.")]
        [MaxLength(20, ErrorMessage = "User name must be less than 20 characters.")]
        public string UserName { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password cannot be null")]
        [MinLength(4, ErrorMessage = "Password must be more than 4 characters.")]
        [MaxLength(20, ErrorMessage = "Password must be less than 20 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
