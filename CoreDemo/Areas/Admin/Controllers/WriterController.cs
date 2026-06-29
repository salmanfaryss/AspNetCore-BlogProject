using Bussiness.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        WriterManager mm = new WriterManager(new EfWriterDal());

        public IActionResult Index()
        {
            var values = mm.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult WriterDetail(int id)
        {
            var values = mm.TGetByID(id);

            return View(values);
        }
    }
}
