using Microsoft.AspNetCore.Mvc;

namespace MovieStore.Controllers
{
    public class CategoryController : Controller
    {
        //private readonly ICategoryRepository _repository;
        //private readonly IMapper _mapper;
        //public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        //{
        //    _repository = categoryRepository;
        //    _mapper = mapper;
        //}
        //public IActionResult Index()
        //{
        //    List<CategoryVM> categories = new List<CategoryVM>();
        //    foreach (var item in _repository.GetAll())
        //    {
        //        categories.Add(_mapper.Map<CategoryVM>(item));
        //    }
        //    return View(categories);
        //}

        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost, ValidateAntiForgeryToken]
        //public IActionResult Create(CategoryVM model)
        //{
        //    CategoryValidator validator = new CategoryValidator();
        //    var validationResults = validator.Validate(model);
        //    if (!validationResults.IsValid)
        //    {
        //        validationResults.AddToModelState(this.ModelState);
        //        return View(model);
        //    }
        //    var newCategory = _mapper.Map<Category>(model);
        //    if (_repository.GetDefault(x=>x.Name == newCategory.Name).Count > 0)
        //    {
        //        TempData["error"] = "The category already exist in the database.";
        //        return View(newCategory);
        //    }
        //    TempData["success"] = "The category is added.";
        //    _repository.Add(newCategory);
        //    return RedirectToAction("index");
        //}

        //public IActionResult Edit(int id)
        //{
        //    return View(_mapper.Map<CategoryVM>(_repository.GetById(id)));
        //}

        //[HttpPost, ValidateAntiForgeryToken]
        //public IActionResult Edit(CategoryVM updateCategory)
        //{
        //    CategoryValidator validator = new CategoryValidator();
        //    var validationResults = validator.Validate(updateCategory);
        //    if (!validationResults.IsValid)
        //    {
        //        validationResults.AddToModelState(this.ModelState);
        //        return View();
        //    }
        //    TempData["success"] = "The category is updated.";
        //    _repository.Update(_mapper.Map<Category>(updateCategory));
        //    return RedirectToAction("index");
        //}

        //public IActionResult Delete(int id)
        //{
        //    return View(_mapper.Map<CategoryVM>(_repository.GetById(id)));
        //}

        //[HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        //public IActionResult DeleteConfirmed(int id)
        //{
        //    _repository.Delete(id);
        //    TempData["success"] = "The category is deleted.";
        //    return RedirectToAction("index");
        //}
        //public IActionResult Details(int id)
        //{
        //    return View(_mapper.Map<CategoryVM>(_repository.GetById(id)));
        //}
    }
}
