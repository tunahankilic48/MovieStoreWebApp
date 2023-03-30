using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.Models.DataTransferObjects.LanguageDTOs;

namespace MovieStore.Controllers
{
    public class LanguageController : Controller
    {
        private readonly Application.Services.LanguageService.ILanguageService _service;
        private readonly IMapper _mapper;
        public LanguageController(Application.Services.LanguageService.ILanguageService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetLanguages());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreateLanguageDTO model)
        {
            if (ModelState.IsValid)
            {
                _service.Create(model);
            }
            return View(model);

        }

        public IActionResult Delete(int id)
        {
            return View(_service.GetById(id));
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);

            return RedirectToAction("index");
        }
    }
}
