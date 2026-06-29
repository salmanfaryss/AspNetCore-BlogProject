using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.WriterPanel
{
    public class WriterPanelFooterComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
