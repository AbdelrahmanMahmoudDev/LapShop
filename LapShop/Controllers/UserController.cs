using LapShop.Data;
using LapShop.Domains.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LapShop.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Register");
        }

        public IActionResult Login()
        {
            return View(new LoginVM());
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View(new AuthVM());
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveRegister(AuthVM authVM)
        {
            if(!ModelState.IsValid)
            {
                return View("Register", authVM);
            }

            var registerResult = await _userManager.CreateAsync(new ApplicationUser
            {
                UserName = authVM.FirstName,
                FirstName = authVM.FirstName,
                LastName = authVM.LastName,
                Email = authVM.Email
            }, authVM.Password);

            if(!registerResult.Succeeded)
            {
                foreach (var error in registerResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View("Register", authVM);
            }

            var signInResult = await _signInManager.PasswordSignInAsync(authVM.Email, authVM.Password, isPersistent: false, lockoutOnFailure: false);

            if(!signInResult.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Login failed. Please check your credentials.");
                return View("Register", authVM); // TODO: Change to login
            }
            if (authVM.ReturnUrl != string.Empty)
            {
                return Redirect(authVM.ReturnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
