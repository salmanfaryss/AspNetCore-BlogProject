using Bussiness.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.ViewComponents.Admin
{
    public class AdminMessageMenu:ViewComponent
    {
        Context c = new Context();
        Message2Manager mm = new Message2Manager(new EfMessage2Dal());
        public IViewComponentResult Invoke()
        {
            var user = User.Identity.Name;
            var userId= c.Users.Where(x => x.UserName == user).Select(x => x.Id).FirstOrDefault();
            var adminId = c.message2.Where(x => x.SenderID == userId ).Select(x => x.SenderID).FirstOrDefault();

            var InboxId = c.message2.Where(x => x.ReceiverID ==userId).Select(x => x.ReceiverID).FirstOrDefault();
            ViewBag.InboxId = mm.InboxMessageCount(2);
            ViewBag.senboxId = mm.SendboxMessageCount(2);
            return View();
        }
    }
}
