using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Models.Entities;
using MovieStore.Repository.Abstract;
using MovieStore.Validation;

namespace MovieStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            return View(_categoryRepository.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category newCategory)
        {
            CategoryValidator validator = new CategoryValidator();
            var validationResults = validator.Validate(newCategory);
            if (!validationResults.IsValid)
            {
                validationResults.AddToModelState(this.ModelState);
                return View(newCategory);
            }

            if (_categoryRepository.GetDefault(x=>x.Name == newCategory.Name).Count > 0)
            {
                TempData["error"] = "The category already exist in the database.";
                return View(newCategory);
            }
            TempData["success"] = "The category is added.";
            _categoryRepository.Add(newCategory);
            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            return View(_categoryRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Category updateCategory)
        {
            CategoryValidator validator = new CategoryValidator();
            var validationResults = validator.Validate(updateCategory);
            if (!validationResults.IsValid)
            {
                validationResults.AddToModelState(this.ModelState);
                return View();
            }
            TempData["success"] = "The category is updated.";
            _categoryRepository.Update(updateCategory);
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            return View(_categoryRepository.GetById(id));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            TempData["success"] = "The category is deleted.";
            _categoryRepository.Delete(id);
            return RedirectToAction("index");
        }
        public IActionResult Details(int id)
        {
            return View(_categoryRepository.GetById(id));
        }
    }
}
