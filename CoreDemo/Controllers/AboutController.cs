using Bussiness.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class AboutController : Controller
    {
        AboutManager ab = new AboutManager(new EfAboutDal());
        public IActionResult Index()
        {
            var values = ab.TGetList();
            return View(values);
        }
        public PartialViewResult SosyalMediaAbout()
        {
            return PartialView();
        }
    }
}
