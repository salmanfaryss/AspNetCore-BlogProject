using Bussiness.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Contact p)
        {
            p.Status = true;
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            cm.TInsert(p);
            TempData["Message"] = "Mesajınız başarlı bir şekilde gönderildi !";
            return View();
        }
    }
}
