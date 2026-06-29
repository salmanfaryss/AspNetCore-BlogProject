using Bussiness.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Dashboard
{
    public class ToDoListDashboard:ViewComponent
    {
        ToDoManager ToDo = new ToDoManager(new EfToDoDal());
        public IViewComponentResult Invoke()
        {
            var values = ToDo.TGetList();
            return View(values);
        }
    }
}
