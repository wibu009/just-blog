using JustBlog.Core.Entities;
using JustBlog.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace JustBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/Admin/Auth/Login");

        }
        public Task<IActionResult> Login()
        {
            if (HttpContext.User.Identity!.IsAuthenticated)
                return Task.FromResult<IActionResult>(Redirect("/admin"));
            return Task.FromResult<IActionResult>(View());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(login.Username, login.Password, false, false);
                if (result.Succeeded)
                {
                    return Redirect("/Admin");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View(login);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
