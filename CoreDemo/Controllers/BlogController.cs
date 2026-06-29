using Bussiness.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreDemo.Controllers
{
   
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        Context c = new Context();

        
       
        public IActionResult BlogList(string search)
        {
           
            search = search ?? "";

            var values = c.blogs
                .Include(x => x.Category)
                .Include(x => x.Writer)
                .Where(x =>
                    x.BlogTitle.Contains(search) ||
                    x.Category.CategoryName.Contains(search) ||
                    x.Writer.WriterName.Contains(search)
                )
                .ToList();
            return View(values);
        }
        public IActionResult ReadMore(int id)
        {
            ViewBag.Id = id;
            var values = bm.TGetByID(id);
            return View(values);
        }
        public IActionResult BlogListByWriter()
        {
            var user = User.Identity.Name;
            var username =  c.Users.Where(x => x.UserName ==user).Select(y => y.NameSurname).FirstOrDefault();
            var writerID = c.writers.Where(x => x.WriterName == username).Select(y => y.WriterID).FirstOrDefault();
            var values = bm.TGetListWithCategoryByWriter(writerID);
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateBlog()
        {
           List<SelectListItem> categoryValues =(from k in cm.TGetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = k.CategoryName,
                                                     Value = k.CategoryID.ToString()
                                                 }).ToList();
            ViewBag.Category = categoryValues;
            return View();
        }
        [HttpPost]
        public IActionResult CreateBlog(Blog p)
        {
            var user = User.Identity.Name;
            var username = c.Users.Where(x => x.UserName == user).Select(y => y.NameSurname).FirstOrDefault();
            var writerID = c.writers.Where(x => x.WriterName == username).Select(y => y.WriterID).FirstOrDefault();
            p.WriterID = writerID;
            p.Status = false;
            p.Date =DateTime.Parse(DateTime.Now.ToShortDateString());
            bm.TInsert(p);
            return RedirectToAction("BlogListByWriter","Blog");
        }
        [HttpGet]
        public IActionResult UpdateBlog(int id)
        {
            List<SelectListItem> categoryValues = (from k in cm.TGetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = k.CategoryName,
                                                       Value = k.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.Category = categoryValues;

            var values = bm.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateBlog(Blog p)
        {
            var user = User.Identity.Name;
            var username = c.Users.Where(x => x.UserName == user).Select(y => y.NameSurname).FirstOrDefault();
            var writerID = c.writers.Where(x => x.WriterName == username).Select(y => y.WriterID).FirstOrDefault();
            p.WriterID = writerID;
            p.Status = true;
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            bm.TInsert(p);
            return RedirectToAction("BlogListByWriter", "Blog");
        }
        public IActionResult ChangeBlogStatusToTrue(int id)
        {
            var values = bm.TGetByID(id);
            bm.TChangeBlogStatusToTrue(values);
            return RedirectToAction("BlogListByWriter", "Blog");
        }
        public IActionResult ChangeBlogStatusToFalse(int id)
        {
            var values = bm.TGetByID(id);
            bm.TChangeBlogStatusToFalse(values);
            return RedirectToAction("BlogListByWriter", "Blog");
        }


    }
}
