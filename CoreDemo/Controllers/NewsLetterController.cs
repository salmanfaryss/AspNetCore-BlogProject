using Bussiness.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class NewsLetterController : Controller
    {
        NewsLetterManager lm = new NewsLetterManager(new EfNewsLetterDal());
        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult SubscribeMail(NewsLetter p)
        {
            p.Status = true;
            lm.TInsert(p);
            TempData["Message"] = "Abone işlemi başarılıdı !";
            Response.Redirect("/Blog/ReadMore/" + 1);
            return View();
        }
    }
}
