using MovieStore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MovieStore.Application.Models.ViewModels.LanguageViewModels
{
    public class LanguageVM
    {
        [Display(Name = "ID")]
        public int? Id { get; set; }

        [Display(Name = "Name")]
        public string? Name { get; set; }

        [Display(Name = "Statu")]
        public Status Statu { get; set; }
    }
}
