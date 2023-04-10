using AutoMapper;
using MovieStore.Application.Models.DataTransferObjects.CategoryDTOs;
using MovieStore.Application.Models.ViewModels.CategoryViewModels;
using MovieStore.Domain.Entities;
using MovieStore.Domain.Enums;
using MovieStore.Domain.Repositories;

namespace MovieStore.Application.Services.CategoryServices
{
    internal class CategoryService : ICategoryService
    {
        // ToDo: Statü göndermesi eklenecek
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<bool> Create(CreateCategoryDTO model)
        {
            Category newCategory = _mapper.Map<Category>(model);
            return await _categoryRepository.Add(newCategory);
        }

        public async Task<bool> Delete(int id)
        {
            Category deleteCategory = await _categoryRepository.GetDefault(x => x.Id == id);
            deleteCategory.Statu = Status.Deleted;
            return await _categoryRepository.Delete(deleteCategory);
        }

        public async Task<UpdateCategoryDTO> GetById(int id)
        {
            Category category = await _categoryRepository.GetDefault(x => x.Id == id);
            return _mapper.Map<UpdateCategoryDTO>(category);
        }

        public async Task<List<CategoryVM>> GetCategories()
        {
            var categories = await _categoryRepository.GetFilteredList(
                select: x => new CategoryVM
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description.Length > 20 ? x.Description.Substring(0,50) : x.Description
                },
                where: x => x.Statu != Status.Passive && x.Statu != Status.Deleted,
                orderby: x => x.OrderBy(x => x.Name)
                );

            return categories;

        }

        public async Task<CategoryDetailsVM> GetCategoryDetails(int id)
        {
            var category = await _categoryRepository.GetFilteredFirstOrDefault(
                select: x => new CategoryDetailsVM
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                },
                where: x => x.Statu != Status.Passive && x.Statu != Status.Deleted,
                include: null
                );

            return category;
        }

        public async Task<bool> Update(UpdateCategoryDTO model)
        {
            Category category = _mapper.Map<Category>(model);
            return await _categoryRepository.Update(category);
        }
    }
}
