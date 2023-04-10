using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Application.Models.DataTransferObjects.AppUserDTOs;
using MovieStore.Application.Services.AppUserServices;

namespace MovieStore.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        //ToDo: Forgot password
        private readonly IAppUserService _userService;

        public AccountController(IAppUserService userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Registor()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (await _userService.IsAdmin(User.Identity.Name))
                    return RedirectToAction("index", "movie", new { Area = "admin" });
                return RedirectToAction("index", "product", new { Area = "customer" });
            }

            return View();
        }
        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public async Task<IActionResult> Registor(RegistorDTO model)
        {
            if(ModelState.IsValid)
            {
                IdentityResult result = await _userService.Registor(model);
                if(result.Succeeded)
                    return RedirectToAction("Index", "Home");

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.Description);
                }

                TempData["error"] = "Something goes wrong";

            }


            return View(model);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = "/")
        {

            if (User.Identity.IsAuthenticated)
            {
                if (await _userService.IsAdmin(User.Identity.Name))
                    return RedirectToAction("index", "movie", new { Area = "admin" });
                return RedirectToAction("index", "product", new { Area = "customer" });
            }

            ViewData["returnUrl"] = returnUrl;
            return View();
        }
        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDTO model, string returnUrl)
        {
            if(ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _userService.Login(model);

                if(result.Succeeded)
                {
                    if (await _userService.IsAdmin(model.UserName))
                        return RedirectToAction("index", "movie", new { Area = "admin" });
                    return RedirectToAction("index", "product", new { Area = "customer" });
                }
                ModelState.AddModelError("", "Invalid login attempt");
            }
            ViewData["returnUrl"] = returnUrl;
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _userService.Logout();
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Edit()
        {

            return View(await _userService.GetByUserName(User.Identity.Name));
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateProfileDTO model)
        {
            if(ModelState.IsValid)
            {
                 await _userService.UpdateUser(model);
                await _userService.Logout();
                
                return RedirectToAction("login");
                
            }
            return View();
        }

        public async Task<IActionResult> Details()
        {
            return View(await _userService.GetByUserName(User.Identity.Name));
        }
    }
}
