using MovieStore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MovieStore.Application.Models.ViewModels.StarringViewModels
{
    public class StarringVM
    {
        public int? Id { get; set; }

        [Display(Name = "Name")]
        public string FullName { get; set; }

        [Display(Name = "Birth Date")]
        public string? BirthDate { get; set; }
        public Status Statu { get; set; }

    }
}
