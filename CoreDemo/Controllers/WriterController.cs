using Bussiness.Concrete;
using CoreDemo.Models;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using DocumentFormat.OpenXml.Spreadsheet;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
   
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterDal());
        UserManager um = new UserManager(new EfUserDal());
        private readonly UserManager<AppUser> _userManager;

        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        Context c = new Context();
        public IActionResult Index()
        {
            Context c = new Context();
            var user = User.Identity.Name;
            //var user = User.Identity.Name;
            //var writername = c.writers.Where(x => x.WriterEmail == user).Select(x => x.WriterName).FirstOrDefault();
            ViewBag.Email = user;
            //ViewBag.Name = writername;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> WriterEditProfile()
        {

            var user =await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel p = new UserUpdateViewModel();
            p.namesurname = user.NameSurname;
            p.email = user.Email;
            p.username = user.UserName;
            p.imageUrl = user.ImageUrl;
            return View(p);


            
        }
        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.Email = p.email;
            user.NameSurname = p.namesurname;
            user.UserName = p.username;
            user.ImageUrl = p.imageUrl;
          
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user,p.password);
            await _userManager.UpdateAsync(user);
             return RedirectToAction("Index","Login");
            
            ////var user = User.Identity.Name;
            ////var writerID = c.writers.Where(x => x.WriterEmail == user).Select(y => y.WriterID).FirstOrDefault();
            ////p.WriterID = writerID;
            ////wm.TUpdate(p);
            //return View();
        }
        [HttpGet]
        public IActionResult CreateWriter()
        {

          
            return View();
        }
        [HttpPost]
        public IActionResult CreateWriter(AddProfileImage p)
        {
            Writer w = new Writer();
            if(p.WriterImage != null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFile/", newImageName);
                var stream = new FileStream(location,FileMode.Create);
                p.WriterImage.CopyTo(stream);
                w.WriterImage =newImageName;

                

            }
            //w.WriterID = 1;
            //w.WriterName = p.WriterName;
            //w.WriterEmail = p.WriterEmail;
            //w.WriterPassword = p.WriterPassword;
            //w.WriterAbout = p.WriterAbout;
            wm.TInsert(w);
            return View();
        }
        public IActionResult Test()
        {
            return View();
        }
    }
}
