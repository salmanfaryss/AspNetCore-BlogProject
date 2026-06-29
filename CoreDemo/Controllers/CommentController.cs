using Bussiness.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoreDemo.Controllers
{
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentDal());
        [HttpGet]
        public PartialViewResult Comment()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult Comment(Comment p)
        {
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.Status = true;
            p.BlogID = 1;
            p.CommentUserImage = "Deneme";
            TempData["Message"] = "Yorumlanızı başarlı bir şekilde gönderildi !";
            cm.TInsert(p);

            return RedirectToAction("ReadMore", "Blog", new { id = p.BlogID });
        }
    }
}
