using AspNetCore;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.Models.DataTransferObjects.MovieDTOS;
using MovieStore.Application.Services.CategoryServices;
using MovieStore.Application.Services.DirectorServices;
using MovieStore.Application.Services.LanguageService;
using MovieStore.Application.Services.MovieServices;
using MovieStore.Application.Services.StarringServices;

namespace MovieStore.Areas.Admin.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ICategoryService _categoryService;
        private readonly IDirectorService _directorService;
        private readonly ILanguageService _languageService;
        private readonly IStarringService _starringService;
        public MovieController(IMovieService movieService, ICategoryService categoryService, IDirectorService directorService, ILanguageService languageService, IStarringService starringService)
        {
            _movieService = movieService;
            _categoryService = categoryService;
            _directorService = directorService;
            _languageService = languageService;
            _starringService = starringService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _movieService.GetMovies());
        }

        public async Task<IActionResult> Create()
        {
            return View(await _movieService.CreateMovie());
        }
        // ToDo: Data taşınacak
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateMovieDTO model)
        {
            // ToDo: oyuncu eklemesi yapılacak
            if (ModelState.IsValid)
            {
                await _movieService.Create(model);
                return RedirectToAction("index");
            }

            return View(model);
        }
        // ToDo: dropdownlar doldurulacak
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _movieService.GetById(id));
        }
        // ToDo: güncelleme yapılıcak, data taşınacak dropboxlara
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateMovieDTO model)
        {
            if (ModelState.IsValid)
            {
                await _movieService.Update(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _movieService.GetById(id));
        }

        [HttpPost, ActionName("delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _movieService.Delete(id);
            return RedirectToAction("index");
        }
        // ToDo: data taşınması gerekebilir
        public async Task<IActionResult> Details(int id)
        {
            return View(await _movieService.GetMovieDetails(id));
        }
    }
}
