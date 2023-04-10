using MovieStore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MovieStore.Application.Models.DataTransferObjects.LanguageDTOs
{
    public class UpdateLanguageDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Language name canot not be null.")]
        [MaxLength(20, ErrorMessage = "Language name can be maximum 20 characters")]
        [Display(Name = "Name")]
        public string? Name { get; set; }
        public Status Statu { get; set; }
    }
}
