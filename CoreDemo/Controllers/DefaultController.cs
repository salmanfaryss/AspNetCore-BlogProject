using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
