using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.Models.DataTransferObjects.LanguageDTOs;
using MovieStore.Application.Services.LanguageService;

namespace MovieStore.Areas.Admin.Controllers
{
    [Area("admin")]
    public class LanguageController : Controller
    {
        // ToDo: statü veri taşınması yapılacak
        // ToDo: Fluent Validation eklenecek
        private readonly ILanguageService _service;
        public LanguageController(ILanguageService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetLanguages());
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateLanguageDTO model)
        {
            if (ModelState.IsValid)
            {
                await _service.Create(model);
            }
            return View(model);

        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await _service.GetById(id));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateLanguageDTO model)
        {
            if (ModelState.IsValid)
            {
                await _service.Update(model);
            }
            return View(model);

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
    }
}
