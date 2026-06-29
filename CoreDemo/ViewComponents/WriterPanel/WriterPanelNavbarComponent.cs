using DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.ViewComponents.WriterPanel
{
    public class WriterPanelNavbarComponent:ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var user = User.Identity.Name;
            var username = c.Users.Where(x => x.UserName == user).Select(y => y.NameSurname).FirstOrDefault();
            ViewBag.writername = c.writers.Where(x => x.WriterName == username).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.WriterAbout = c.writers.Where(x => x.WriterName == username).Select(y => y.WriterAbout).FirstOrDefault();
            ViewBag.writerImage = c.writers.Where(x => x.WriterName == username).Select(y => y.WriterImage).FirstOrDefault();
            ViewBag.writerEmail = username;
            return View();
        }
    }
}
