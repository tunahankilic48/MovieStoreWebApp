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
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        [HttpPost, AllowAnonymous]
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
                return RedirectToAction("Index", "Home");
            }

            ViewData["returnUrl"] = returnUrl;
            return View();
        }
        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login(LoginDTO model, string returnUrl)
        {
            if(ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _userService.Login(model);

                if(result.Succeeded)
                    return Redirect(returnUrl);
                ModelState.AddModelError("", "Invalid login attempt");
            }

            bool deneme = User.Identity.IsAuthenticated;
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _userService.Logout();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Edit()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateProfileDTO model)
        {
            return View();
        }

        public async Task<IActionResult> Details()
        {
            await _userService.GetByUserName(User.Identity.Name);
            return View(await _userService.GetByUserName(User.Identity.Name));
        }
    }
}
