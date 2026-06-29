using Bussiness.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminNotificationController : Controller
    {
        NotificationManager nm = new NotificationManager(new EfNotificationDal());
        public IActionResult Index()
        {
            var values = nm.TGetList();
            return View(values);
        }
    }
}
