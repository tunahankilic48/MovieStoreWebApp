﻿using MovieStore.Domain.Entities;
using MovieStore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Application.Models.ViewModels.StarringViewModels
{
    internal class StarringDetailsVM
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public Status Statu { get; set; }

        public List<Movie>? PerformedMovies { get; set; }
    }
}
