using Bussiness.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminToDoController : Controller
    {
        ToDoManager ToDoManager = new ToDoManager(new EfToDoDal());
        public IActionResult Index()
        {
            var values = ToDoManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateToDo()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateToDo(ToDo p)
        {
            p.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            ToDoManager.TInsert(p);
            return RedirectToAction("Index", "AdminToDo");
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}
