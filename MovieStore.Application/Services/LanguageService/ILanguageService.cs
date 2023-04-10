using MovieStore.Application.Models.DataTransferObjects.LanguageDTOs;
using MovieStore.Application.Models.ViewModels.LanguageViewModels;

namespace MovieStore.Application.Services.LanguageService
{
    public interface ILanguageService
    {
        Task<bool> Create(CreateLanguageDTO model);
        Task<bool> Delete(int id);
        Task<bool> Update(UpdateLanguageDTO model);
        Task<UpdateLanguageDTO> GetById(int id);
        Task<List<LanguageVM>> GetLanguages();
    }
}
