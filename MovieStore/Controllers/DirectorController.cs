using Microsoft.AspNetCore.Mvc;
using MovieStore.Models.Entities;
using MovieStore.Repository.Abstract;

namespace MovieStore.Controllers
{
    public class DirectorController : Controller
    {
        private readonly IDirectorRepository _repository;

        public DirectorController(IDirectorRepository directorRepository)
        {
            _repository = directorRepository;
        }

        public IActionResult Index()
        {
            return View(_repository.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Director newDirector)
        {
            _repository.Add(newDirector);
            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            return View(_repository.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Director updatedDirector)
        {
            _repository.Update(updatedDirector);
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            return View(_repository.GetById(id));
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("index");
        }

        public IActionResult Details(int id)
        {
            return View(_repository.GetById(id));
        }

    }
}
