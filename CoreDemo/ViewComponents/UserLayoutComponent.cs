using DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.ViewComponents
{
    public class UserLayoutComponent:ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var user = User.Identity.Name;
            var username = c.Users.Where(x => x.UserName ==user).Select(x => x.NameSurname).FirstOrDefault();
            ViewBag.UserName = username;
            return View();
        }
    }
}
