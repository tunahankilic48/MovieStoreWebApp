using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieStore.Models.Entities;
using MovieStore.Models.ViewModels;
using MovieStore.Repository.Abstract;
using MovieStore.Validation;
using NuGet.Protocol.Core.Types;

namespace MovieStore.Controllers
{
    public class StarringController : Controller
    {
        private readonly IStarringRepository _repository;
        private readonly IMapper _mapper;

        public StarringController(IStarringRepository starringRepository, IMapper mapper)
        {
            _repository = starringRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            List<StarringVM> starrings = new List<StarringVM>();
            foreach (var item in _repository.GetAll())
            {
                starrings.Add(_mapper.Map<StarringVM>(item));
            }
            return View(starrings);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StarringVM newStarring)
        {
            StarringValidation validator = new StarringValidation();
            var results = validator.Validate(newStarring);

            if(results.IsValid)
            {
                _repository.Add(_mapper.Map<Starring>(newStarring));
                TempData["success"] = "New starring is added successfully";
                return RedirectToAction("index");
            }
            results.AddToModelState(this.ModelState);
            return View(newStarring);
        }

        public IActionResult Edit(int id)
        {
            return View(_mapper.Map<StarringVM>(_repository.GetById(id)));
        }

        [HttpPost]
        public IActionResult Edit(StarringVM updatedStarring)
        {
            StarringValidation validator = new StarringValidation();
            var results = validator.Validate(updatedStarring);
            if (results.IsValid)
            {
                _repository.Update(_mapper.Map<Starring>(updatedStarring));
                TempData["success"] = "Starring is updated successfully";
                return RedirectToAction("index");
            }

            results.AddToModelState(this.ModelState);
            return View(updatedStarring);
        }

        public IActionResult Delete(int id)
        {
            return View(_mapper.Map<StarringVM>(_repository.GetById(id)));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            TempData["success"] = "Starring is deleted successfully";
            return RedirectToAction("index");
        }

        public IActionResult Details(int id)
        {
            ViewBag.PerformedMovies = new SelectList(_repository.GetById(id).PerformedMovies, "Id", "Name");

            return View(_mapper.Map<StarringVM>(_repository.GetById(id)));
        }
    }
}
