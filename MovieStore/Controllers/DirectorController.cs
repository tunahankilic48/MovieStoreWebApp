using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieStore.Models.Entities;
using MovieStore.Models.ViewModels;
using MovieStore.Repository.Abstract;
using NuGet.Protocol;

namespace MovieStore.Controllers
{
    public class DirectorController : Controller
    {
        private readonly IDirectorRepository _repository;
        private readonly IMapper _mapper;

        public DirectorController(IDirectorRepository directorRepository, IMapper mapper)
        {
            _repository = directorRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            List<DirectorVM> directors = new List<DirectorVM>();
            foreach (var item in _repository.GetAll())
            {
                directors.Add(_mapper.Map<DirectorVM>(item));
            }
            return View(directors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(DirectorVM newDirector)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(_mapper.Map<Director>(newDirector));
                TempData["success"] = "New director is added successfully";
                return RedirectToAction("index");
            }

            return View(newDirector);

        }

        public IActionResult Edit(int id)
        {
            return View(_mapper.Map<DirectorVM>(_repository.GetById(id)));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(DirectorVM updatedDirector)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(_mapper.Map<Director>(updatedDirector));
                TempData["success"] = "Director is updated successfully";
                return RedirectToAction("index");
            }
            return View(updatedDirector);
        }

        public IActionResult Delete(int id)
        {
            return View(_mapper.Map<DirectorVM>(_repository.GetById(id)));
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            TempData["success"] = "Director is deleted successfully";
            return RedirectToAction("index");
        }

        public IActionResult Details(int id)
        {
            ViewBag.DirectedMovies = new SelectList(_repository.GetById(id).DirectedMovies, "Id", "Name");

            return View(_mapper.Map<DirectorVM>(_repository.GetById(id)));
        }

    }
}
