using Bussiness.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.WriterPanel
{
    public class WriterActiviteComponent:ViewComponent
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Dal());
        public IViewComponentResult Invoke()
        {
            var values = mm.TGetListWithUsers();
            return View(values);
        }
    }
}
