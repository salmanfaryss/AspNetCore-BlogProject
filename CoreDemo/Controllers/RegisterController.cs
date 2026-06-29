using Bussiness.Concrete;
using Bussiness.ValidationRules;
using CoreDemo.Models;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterDal());
       WriterValidator vm = new WriterValidator();
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        Context c = new Context();

        public RegisterController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserSignUpViewModel p)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    UserName = p.UserName,
                    Email = p.Email,
                    NameSurname = p.namesurname,

                };


                var result = await _userManager.CreateAsync(appUser, p.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
          
           return View();
        }

        [HttpGet]
        public IActionResult RegisterLogin()
        {
            return View();
        }
        [HttpPost]
       
        public async Task<IActionResult> RegisterLogin(UserSignInViewModel p)
        {
            var result = await _signInManager.PasswordSignInAsync(p.username, p.password,false,true);
            if (result.Succeeded)
            {
                return RedirectToAction("RegisterUser", "Register");
            }
            return View();
        }
        [HttpGet]
        public IActionResult UpdateUser()
        {
            return View();
        }
        [HttpPost]
        [HttpGet]
        public IActionResult UpdateUser(UserSignUpViewModel p)
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateCompte()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCompte(UserSignUpViewModel p)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    UserName = p.UserName,
                    Email = p.Email,
                    NameSurname = p.namesurname,
                    

                };


                var result = await _userManager.CreateAsync(appUser, p.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(appUser, "writer");
                    Writer writer = new Writer()
                    {
                        WriterName = p.namesurname,
                        WriterImage = "/images/default.png",
                        WriterAbout = "",
                        WriterAboutDetail = "",
                        WriterAdres = "",

                        AppUserId = appUser.Id
                    };
                    c.writers.Add(writer);
                    
                    await c.SaveChangesAsync();

                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View();
          
        }


    }
}
