using DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WidgetController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            ViewBag.TotalMessage = c.message2.Count();
            ViewBag.BlogCount =c.blogs.Count();
            ViewBag.CommentCount =c.comments.Count();
            ViewBag.NotificationCount = c.notification.Count();

            var today = DateTime.Today;
            ViewBag.TodayBlogCount = c.blogs.Where(x => x.Date == today).Count();
            return View();
        }
    }
}
