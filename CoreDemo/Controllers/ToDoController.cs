using Bussiness.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoreDemo.Controllers
{
    public class ToDoController : Controller
    {
        ToDoManager tm = new ToDoManager(new EfToDoDal());
        public IActionResult ToDoList()
        {
            var values = tm.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateToDo()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateToDo(ToDo p)
        {
            p.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.Priority = PriorityLevel.High;
            p.Status = true;
           
           
            tm.TInsert(p);
            return RedirectToAction("ToDoList","ToDo");
        }
        [HttpGet]
        public IActionResult UpdateToDo(int id)
        {
            var values = tm.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateToDo( ToDo p)
        {
            
            p.Status = false;
            p.Priority = PriorityLevel.Urgent;
            p.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.UpdateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
        tm.TUpdate(p);
         return RedirectToAction("ToDoList", "ToDo");
        }
    }
}
