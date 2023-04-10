using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.Services.MovieServices;

namespace MovieStore.Areas.Customer.Controllers
{
    [Area("customer"), Authorize(Roles = "Customer")]

    public class ProductController : Controller
    {
        private readonly IMovieService _movieService;

        public ProductController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _movieService.GetMovies());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _movieService.GetMovieDetailsForCustomers(id));
        }
    }
}
