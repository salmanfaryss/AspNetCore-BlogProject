using DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.ViewComponents.Statistic
{
    public class Static2Component:ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.WriterCount = c.writers.Count();
            ViewBag.TotalMessage = c.message2.Count();
            return View();
        }
    }
}
