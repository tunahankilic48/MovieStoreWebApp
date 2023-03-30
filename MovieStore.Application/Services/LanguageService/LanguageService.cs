using AutoMapper;
using MovieStore.Application.Models.DataTransferObjects.LanguageDTOs;
using MovieStore.Application.Models.ViewModels.LanguageViewModels;
using MovieStore.Domain.Entities;
using MovieStore.Domain.Enums;
using MovieStore.Domain.Repositories;

namespace MovieStore.Application.Services.LanguageService
{
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;
        public LanguageService(ILanguageRepository languageRepository, IMapper mapper)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        public async Task<bool> Create(CreateLanguageDTO model)
        {
            Language newLanguage = _mapper.Map<Language>(model);
            return await _languageRepository.Add(newLanguage);
        }

        public async Task<bool> Delete(int id)
        {
            Language deleteLanguage = await _languageRepository.GetDefault(x => x.Id == id);
            deleteLanguage.Statu = Status.Deleted;
            return await _languageRepository.Delete(deleteLanguage);
        }

        public async Task<LanguageVM> GetById(int id)
        {
            Language Language = await _languageRepository.GetDefault(x => x.Id == id);
            return _mapper.Map<LanguageVM>(Language);
        }

        public async Task<List<LanguageVM>> GetLanguages()
        {
            var languages = await _languageRepository.GetFilteredList(
                select: x => new LanguageVM
                {
                    Id = x.Id,
                    Name = x.Name,
                    Statu = x.Statu
                },
                where: x => x.Statu != Status.Passive && x.Statu != Status.Deleted,
                orderby: x => x.OrderBy(x => x.Name),
                include: null
                );

            return languages;
        }
    }
}
