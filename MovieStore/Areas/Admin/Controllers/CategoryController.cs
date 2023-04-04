using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.Models.DataTransferObjects.CategoryDTOs;
using MovieStore.Application.Services.CategoryServices;

namespace MovieStore.Areas.Admin.Controllers
{
    [Area("admin")]
    public class CategoryController : Controller
    {
        // ToDo: Statü göndermesi eklenecek

        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetCategories());
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                await _service.Create(model);
                return RedirectToAction("index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await _service.GetById(id));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateCategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                await _service.Update(model);
                return RedirectToAction("index");
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
        public async Task<IActionResult> Details(int id)
        {
            return View(await _service.GetCategoryDetails(id));
        }
    }
}
