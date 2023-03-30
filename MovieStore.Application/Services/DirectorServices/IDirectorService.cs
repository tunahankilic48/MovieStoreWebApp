using MovieStore.Application.Models.DataTransferObjects.CategoryDTOs;
using MovieStore.Application.Models.DataTransferObjects.DirectorDTOs;
using MovieStore.Application.Models.ViewModels.DirectorViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Application.Services.DirectorServices
{
    internal interface IDirectorService
    {
        Task<bool> Create(CreateDirectorDTO model);
        Task<bool> Delete(int id);
        Task<bool> Update(UpdateDirectorDTO model);
        Task<UpdateDirectorDTO> GetById(int id);
        Task<List<DirectorVM>> GetDirectors();
        Task<DirectorDetailsVM> GetDirectorDetails(int id);
    }
}
