using LapShop.Data;
using LapShop.Domains.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

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

        public async Task<IActionResult> SaveLogin(LoginVM loginVM)
        {
            if(!ModelState.IsValid)
            {
                return View("Login", loginVM);
            }

            var user = await _userManager.FindByEmailAsync(loginVM.Email);

            var signInResult = await _signInManager.PasswordSignInAsync(user.UserName, loginVM.Password, isPersistent: false, lockoutOnFailure: false);
            if(!signInResult.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Login failed. Please check your credentials.");
                return View("Login", loginVM);
            }
            if (!string.IsNullOrEmpty(loginVM.ReturnUrl))
            {
                return Redirect(loginVM.ReturnUrl);
            }
            return RedirectToAction("Index", "Home");
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

            var signInResult = await _signInManager.PasswordSignInAsync(authVM.FirstName, authVM.Password, isPersistent: false, lockoutOnFailure: false);

            if(!signInResult.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Login failed. Please check your credentials.");
                return View("Login", new LoginVM { Email = authVM.Email });
            }
            if (!string.IsNullOrEmpty(authVM.ReturnUrl))
            {
                return Redirect(authVM.ReturnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
