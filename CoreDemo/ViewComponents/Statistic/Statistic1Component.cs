using DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CoreDemo.ViewComponents.Statistic
{
    public class Statistic1Component:ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.TotalViews = c.blogs.Select(x => x.BlogViews).Sum();
            ViewBag.NewsComments = c.comments.OrderByDescending(x => x.CommentID).Take(5).Count();
            ViewBag.TotalBlogCount = c.blogs.Count();
            ViewBag.TrueBlogCount = c.blogs.Where(x => x.Status ==true).Count();

            var bugunTarih = DateTime.Today;
            ViewBag.TodayBlogCount = c.blogs.Where(x => x.Date == bugunTarih).Count();

            var month = DateTime.Now;
            ViewBag.MonthBlogContent = c.blogs.Where(x => x.Date.Year == month.Year && x.Date.Month == month.Month).Count();

            return View();
        }
    }
}
