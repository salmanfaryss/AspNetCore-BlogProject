using Bussiness.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminProfileController : Controller
    {
        Context c = new Context();
        BlogManager bm = new BlogManager(new EfBlogDal());
        public IActionResult Index()
        {
            var user = User.Identity.Name;
            var username = c.Users.Where(x => x.UserName ==user).Select(y => y.NameSurname).FirstOrDefault();
            ViewBag.WriterImage = c.writers.Where(x => x.WriterName == username).Select(y => y.WriterImage).FirstOrDefault();
            ViewBag.WriterName = c.writers.Where(x => x.WriterName == username).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.WriterAbout = c.writers.Where(x => x.WriterName ==username).Select(y => y.WriterAbout).FirstOrDefault();
            ViewBag.WriterAboutDetail = c.writers.Where(x => x.WriterName ==username).Select(y => y.WriterAboutDetail).FirstOrDefault();
            var WriterID = c.writers.Where(x => x.WriterName ==username).Select(y => y.WriterID).FirstOrDefault();
            ViewBag.WriterBlogCount = bm.TWriterTotalBlogCount(WriterID);
            return View();

            //var username = User.Identity.Name;
            //var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.NameSurname).FirstOrDefault();
            //var writerId = c.writers.Where(x => x.WriterName == usermail).Select(y => y.WriterID).FirstOrDefault();
            //var values = mm.GetInboxListByWriter(writerId);
        }
    }
}
