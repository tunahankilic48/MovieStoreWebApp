using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.Services.MovieServices;

namespace MovieStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;

        public HomeController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _movieService.GetMovies());
        }
    }
}
