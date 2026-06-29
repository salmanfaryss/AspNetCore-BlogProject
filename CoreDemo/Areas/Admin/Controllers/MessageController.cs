using Bussiness.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Dal());
        UserManager um = new UserManager(new EfUserDal());
        Context c = new Context();
        public IActionResult Inbox()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.NameSurname).FirstOrDefault();
            var writerId = c.writers.Where(x => x.WriterName == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = mm.GetInboxListByWriter(writerId);
            return View(values);
        }
        public IActionResult SendBox()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.NameSurname).FirstOrDefault();
            var writerId = c.writers.Where(x => x.WriterName == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = mm.GetInboxListByWriter(writerId);
            return View(values);
        }
        public IActionResult InboxMessageDetail(int id)
        {
            var values = mm.GetMessageDetail(id);
            mm.TChangeStatusToTrue(values);
            return View(values);
        }
        public IActionResult SendMessageDetail(int id)
        {
            var values = mm.GetMessageDetail(id);
            mm.TChangeStatusToTrue(values);
            return View(values);
           
        }
        [HttpGet]
        public async Task<IActionResult> NewMessage()
        {
            List<SelectListItem> ReceiverUser = (from x in await um.TGetUserAsync()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Email.ToString(),
                                                     Value = x.Id.ToString()
                                                 }).ToList();


            ViewBag.receiverUser = ReceiverUser;

            return View();
        }
        [HttpPost]
        public IActionResult NewMessage(Message2 p)
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.NameSurname).FirstOrDefault();
            var writerID = c.writers.Where(x => x.WriterName == usermail).Select(y => y.WriterID).FirstOrDefault();

            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.IsReady = false;
            p.SenderID = writerID;


            mm.TInsert(p);
            return RedirectToAction("Inbox", "Message");
           
        }

    }
}
