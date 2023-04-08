using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.Services.MovieServices;

namespace MovieStore.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IMovieService _movieService;

        public ProductController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _movieService.GetMovieDetailsForCustomers(id));
        }
    }
}
