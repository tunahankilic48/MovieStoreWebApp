using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.Models.DataTransferObjects.LanguageDTOs;

namespace MovieStore.Controllers
{
    public class LanguageController : Controller
    {
        private readonly Application.Services.LanguageService.ILanguageService _service;
        public LanguageController(Application.Services.LanguageService.ILanguageService service)
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
