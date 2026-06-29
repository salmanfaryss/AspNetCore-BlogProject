using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Widget
{
    public class WidgetHeadComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
