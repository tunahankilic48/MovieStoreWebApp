using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.Models.DataTransferObjects.StarringDTOs;
using MovieStore.Application.Services.StarringServices;

namespace MovieStore.Areas.Admin.Controllers
{
    public class StarringController : Controller
    {
        // ToDo: Filmler gönderilecek
        // ToDo: Statü yapılacak
        // ToDo: FluentValidation Yapılacak
        private readonly IStarringService _service;

        public StarringController(IStarringService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetStarrings());
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateStarringDTO newStarring)
        {
            if (ModelState.IsValid)
            {
                await _service.Create(newStarring);
                return RedirectToAction("index");
            }

            return View(newStarring);
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await _service.GetById(id));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateStarringDTO updatedStarring)
        {
            if (ModelState.IsValid)
            {
                await _service.Update(updatedStarring);
                return RedirectToAction("index");
            }

            return View(updatedStarring);
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
            return View(await _service.GetStarringDetails(id));
        }
    }
}
