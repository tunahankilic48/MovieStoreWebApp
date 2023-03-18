using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieStore.Models.Entities;
using MovieStore.Models.ViewModels;
using MovieStore.Repository.Abstract;
using MovieStore.Validation;

namespace MovieStore.Controllers
{
    public class LanguageController : Controller
    {
        private readonly ILanguageRepository _repository;
        private readonly IMapper _mapper;
        public LanguageController(ILanguageRepository categoryRepository, IMapper mapper)
        {
            _repository = categoryRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            List<LanguageVM> languages = new List<LanguageVM>();
            foreach (var item in _repository.GetAll())
            {
                languages.Add(_mapper.Map<LanguageVM>(item));
            }
            return View(languages);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(LanguageVM model)
        {
            if (ModelState.IsValid)
            {
                var newLanguage = _mapper.Map<Language>(model);
                if (_repository.GetDefault(x => x.Name == newLanguage.Name).Count > 0)
                {
                    TempData["error"] = "The language already exist in the database.";
                    return View(newLanguage);
                }
                TempData["success"] = "The category is added.";
                _repository.Add(newLanguage);
            }

            return View(model);

        }

        public IActionResult Delete(int id)
        {
            return View(_mapper.Map<LanguageVM>(_repository.GetById(id)));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            TempData["success"] = "Language is deleted successfully";
            return RedirectToAction("index");
        }
    }
}
