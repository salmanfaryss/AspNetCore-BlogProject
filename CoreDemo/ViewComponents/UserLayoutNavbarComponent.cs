using DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.ViewComponents
{
    public class UserLayoutNavbarComponent:ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke(string search)
        {
            var values = c.blogs.Where(x => x.BlogTitle.Contains(search ?? "") || x.Category.CategoryName.Contains(search ?? "") || x.Writer.WriterName.Contains(search ?? "")).ToList();
            return View(values);
        }
    }
}
