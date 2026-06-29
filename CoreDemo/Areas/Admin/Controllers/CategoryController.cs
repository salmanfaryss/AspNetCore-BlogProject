using Bussiness.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using X.PagedList.Extensions;
using X.PagedList.Mvc.Core;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {

        CategoryManager cm = new CategoryManager(new EfCategoryDal());
       
        public IActionResult CategoryList(int sayfa = 1)
        {
            var values = cm.TGetList().ToPagedList(sayfa,10);
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(Category p)
        {
            p.Status = false;
            cm.TInsert(p);
            return RedirectToAction("CategoryList","Category");
        }

        public IActionResult ChangeStatusToTrue(int id)
        {
            var values = cm.TGetByID(id);
            cm.TChangeStatusToTrue(values);
            return RedirectToAction("CategoryList","Category");
        }
        public IActionResult ChangeStatusToFalse(int id)
        {
            var values = cm.TGetByID(id);
            cm.TChangeStatusToFalse(values);
            return RedirectToAction("CategoryList", "Category");
        }
    }
}
