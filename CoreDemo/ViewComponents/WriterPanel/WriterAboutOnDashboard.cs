using Bussiness.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace CoreDemo.ViewComponents.WriterPanel
{
    public class WriterAboutOnDashboard:ViewComponent
    {
        WriterManager wm = new WriterManager(new EfWriterDal());
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            var user = User.Identity.Name;
            var username  = c.Users.Where(x => x.UserName == user).Select(y => y.NameSurname).FirstOrDefault();
            var writerId = c.writers.Where(x => x.WriterName == username).Select(y => y.WriterID).FirstOrDefault();
            var values = wm.TGetWriterByID(writerId);
            ViewBag.writerName = c.writers.Where(x => x.WriterName ==username).Select(y =>y.WriterName).FirstOrDefault();
            return View(values);

            

            

        }
    }
}
