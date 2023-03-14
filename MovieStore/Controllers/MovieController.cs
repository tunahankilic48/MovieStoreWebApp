using Microsoft.AspNetCore.Mvc;
using MovieStore.Models.Entities;
using MovieStore.Repository.Abstract;

namespace MovieStore.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public IActionResult Index()
        {
            return View(_movieRepository.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie newMovie)
        {
            _movieRepository.Add(newMovie);
            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            return View(_movieRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Movie updateMovie)
        {
            _movieRepository.Update(updateMovie);
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            return View(_movieRepository.GetById(id));
        }

        [HttpPost, ActionName("delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _movieRepository.Delete(id);
            return RedirectToAction("index");
        }


    }
}
