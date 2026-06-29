using CoreDemo.Models;
using DataAccess.Concrete;
using Entity.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        //Context c = new Context();

        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserSignUpViewModel p)
        {
            var result = await _signInManager.PasswordSignInAsync(p.UserName, p.Password,false,true);
           
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(p.UserName);
                var role = await _userManager.GetRolesAsync(user);
                if (role.Contains("Admin"))
                {
                    return RedirectToAction("Index", "Blog", new { area = "Admin" });
                }
                if (role.Contains("Moderator"))
                {
                    return RedirectToAction("Index", "Blog", new { area = "Admin" });
                }
                if (role.Contains("Writer"))
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                if (role.Contains("Member"))
                {
                    return RedirectToAction("BlogList", "Blog");
                }
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }
      
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
