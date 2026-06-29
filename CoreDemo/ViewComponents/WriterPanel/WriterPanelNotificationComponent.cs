using Bussiness.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace CoreDemo.ViewComponents.WriterPanel
{
    public class WriterPanelNotificationComponent:ViewComponent
    {
        NotificationManager nm = new NotificationManager(new EfNotificationDal());
        public IViewComponentResult Invoke()
        {
            var values = nm.TGet6Notification();
            return View(values);
        }
    }
}
