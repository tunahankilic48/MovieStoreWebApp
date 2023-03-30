using MovieStore.Application.Models.DataTransferObjects.CategoryDTOs;
using MovieStore.Application.Models.ViewModels.CategoryViewModels;

namespace MovieStore.Application.Services.CategoryServices
{
    internal interface ICategoryService
    {
        Task<bool> Create(CreateCategoryDTO model);
        Task<bool> Delete(int id);
        Task<bool> Update(UpdateCategoryDTO model);
        Task<UpdateCategoryDTO> GetById(int id);
        Task<List<CategoryVM>> GetCategories();
        Task<CategoryVM> GetCategoryDetails(int id);

    }
}
