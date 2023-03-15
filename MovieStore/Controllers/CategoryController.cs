using Microsoft.AspNetCore.Mvc;
using MovieStore.Models.DataAccess;
using MovieStore.Models.Entities;
using MovieStore.Repository.Abstract;
using MovieStore.Repository.Concrete;

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
            _categoryRepository.Delete(id);
            return RedirectToAction("index");
        }
        public IActionResult Details(int id)
        {
            return View(_categoryRepository.GetById(id));
        }
    }
}
