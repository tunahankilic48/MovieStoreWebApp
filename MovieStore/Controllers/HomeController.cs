using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.Services.AppUserServices;
using MovieStore.Application.Services.MovieServices;

namespace MovieStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IAppUserService _appUserService;

        public HomeController(IMovieService movieService, IAppUserService appUserService)
        {
            _movieService = movieService;
            _appUserService = appUserService;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if(await _appUserService.IsAdmin(User.Identity.Name))
                    return RedirectToAction("index", "movie", new { Area = "admin" });
                return RedirectToAction("index", "product", new { Area = "customer" });
            }
            return View(await _movieService.GetMovies());
        }
    }
}
