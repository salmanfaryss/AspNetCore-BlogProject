using Bussiness.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.ViewComponents.WriterPanel
{
    public class WriterPanelMessageNotificationComponent:ViewComponent
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Dal());
        Context c = new Context();
        public IViewComponentResult Invoke(int id)
        {
            //var username = User.Identity.Name;
            //var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            //var writerID = c.writers.Where(x => x.WriterEmail == usermail).Select(y => y.WriterID).FirstOrDefault();
            //var values = mm.GetSenboxListByWriter(writerID);
            var values = mm.TGetListWithUsers();
            return View(values);
        }
    }
}
