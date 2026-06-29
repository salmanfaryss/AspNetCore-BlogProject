using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Admin
{
    public class AdminNavbarComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
