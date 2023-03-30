using MovieStore.Application.Models.DataTransferObjects.StarringDTOs;
using MovieStore.Application.Models.ViewModels.StarringViewModels;

namespace MovieStore.Application.Services.StarringServices
{
    internal interface IStarringService
    {
        Task<bool> Create(CreateStarringDTO model);
        Task<bool> Delete(int id);
        Task<bool> Update(UpdateStarringDTO model);
        Task<UpdateStarringDTO> GetById(int id);
        Task<List<StarringVM>> GetStarrings();
        Task<StarringDetailsVM> GetStarringDetails(int id);
    }
}
