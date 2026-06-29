using Bussiness.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class DashboardController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        Context c = new Context();
        public IActionResult Index()
        {
            var user = User.Identity.Name;
            var username = c.Users.Where(x => x.UserName ==user).Select(y => y.NameSurname).FirstOrDefault();
            var writerId = c.writers.Where(x => x.WriterName == username).Select(y => y.WriterID).FirstOrDefault();
            ViewBag.BlogCount = bm.TTotalBlogCount();
            ViewBag.BlogByWriterCount = bm.TWriterTotalBlogCount(writerId);
            ViewBag.CategoryCount = cm.TCategoryCount();

            return View();
        }
    }
}
