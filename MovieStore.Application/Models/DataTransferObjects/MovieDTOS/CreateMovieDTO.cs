﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using MovieStore.Application.Models.ViewModels.CategoryViewModels;
using MovieStore.Application.Models.ViewModels.DirectorViewModels;
using MovieStore.Application.Models.ViewModels.LanguageViewModels;
using MovieStore.Application.Models.ViewModels.StarringViewModels;
using MovieStore.Domain.Entities;
using MovieStore.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MovieStore.Application.Models.DataTransferObjects.MovieDTOS
{
    public class CreateMovieDTO
    {
        [Required(ErrorMessage = "Name cannot be null.")]
        [MaxLength(50, ErrorMessage = "Name cannot be more than 50 characters.")]
        [Display(Name = "Name")]
        public string? Name { get; set; }

        [MaxLength(250, ErrorMessage = "Description cannot be more than 250 characters.")]
        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Category cannot be null.")]
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }

        [Required(ErrorMessage = "Director cannot be null.")]
        [Display(Name = "Director")]
        public int? DirectorId { get; set; }

        [Required(ErrorMessage = "Release date cannot be null.")]
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }

        [Range(10, 1000, ErrorMessage = ("Time must be between 10-1000 minutes."))]
        [Display(Name = "Running Time (Min)")]
        public int? RunningTimeMin { get; set; }

        [Required(ErrorMessage = "Language cannot be null.")]
        [Display(Name = "Language")]
        public int? LanguageId { get; set; }

        [Required(ErrorMessage = "Price cannot be null.")]
        [Display(Name = "Price")]
        [Range(0, 99999.99, ErrorMessage = ("Price must be between 0-99.999,99."))]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Stock cannot be null.")]
        [Display(Name = "Stock")]
        [Range(0, 100000, ErrorMessage = ("Stock must be between 0-100.000."))]
        public int? Stock { get; set; }

        [Display(Name = "Is Active")]
        [ValidateNever]
        public bool IsActive { get; set; }

        [ValidateNever]
        public IFormFile? Image { get; set; }

        [ValidateNever]
        public string? ImagePath { get; set; }

        [ValidateNever]
        [Display(Name = "Starrings that can be added")]
        public List<int> AddStarringsIds { get; set; }

        [ValidateNever]
        [Display(Name = "Current Starrings")]
        public List<int> DeleteStarringsIds { get; set; }
        public Status Statu => Status.Active;

        public List<CategoryVM>? Categories { get; set; }
        public List<DirectorVM>? Directors { get; set; }
        public List<LanguageVM>? Languages { get; set; }



        public List<StarringVM>? StarringsThatRoleInMovie { get; set; }
        public List<StarringVM>? Starrings { get; set; }
    }
}
