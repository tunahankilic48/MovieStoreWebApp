using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.Models.DataTransferObjects.DirectorDTOs;
using MovieStore.Application.Services.DirectorServices;

namespace MovieStore.Areas.Admin.Controllers
{
    [Area("admin")]
    public class DirectorController : Controller
    {
        // ToDo: Yönetilen Filmler dropbox a dolacak
        // ToDo: Statü doldurulacak
        private readonly IDirectorService _service;

        public DirectorController(IDirectorService service)
        {
            _service = service;

        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetDirectors());
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateDirectorDTO newDirector)
        {
            if (ModelState.IsValid)
            {
                await _service.Create(newDirector);
                return RedirectToAction("index");
            }

            return View(newDirector);

        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await _service.GetById(id));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateDirectorDTO updatedDirector)
        {
            if (ModelState.IsValid)
            {
                await _service.Update(updatedDirector);
                return RedirectToAction("index");
            }
            return View(updatedDirector);
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _service.GetById(id));
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.Delete(id);
            return RedirectToAction("index");
        }

        public async Task<IActionResult> Details(int id)
        {

            return View(await _service.GetDirectorDetails(id));
        }
    }
}
