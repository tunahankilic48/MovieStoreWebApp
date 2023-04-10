using MovieStore.Application.Models.DataTransferObjects.DirectorDTOs;
using MovieStore.Application.Models.ViewModels.DirectorViewModels;

namespace MovieStore.Application.Services.DirectorServices
{
    public interface IDirectorService
    {
        Task<bool> Create(CreateDirectorDTO model);
        Task<bool> Delete(int id);
        Task<bool> Update(UpdateDirectorDTO model);
        Task<UpdateDirectorDTO> GetById(int id);
        Task<List<DirectorVM>> GetDirectors();
        Task<DirectorDetailsVM> GetDirectorDetails(int id);
    }
}
