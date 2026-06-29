using BlogApi.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {

        [HttpGet]
        public IActionResult EmployeeList()
        {
            using(var c = new Context())
            {
                var values = c.Employees.ToList();
                return Ok(values); ;
            }
           
        }
        [HttpPost]
        public IActionResult EmployeeAd(Employee p)
        {
            using(var c = new Context())
            {
                c.Add(p);
                c.SaveChanges();
            }
            return Ok("Başarılı bir şekilde eklendi");
        }
        [HttpGet("GetEmployeeByID")]
        public IActionResult GetEmployeeByID(int id)
        {
            using(var c = new Context())
            {
                var values = c.Employees.Find(id);

                if(values == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(values);
                }
            }
        }
        [HttpDelete]
        public IActionResult DeleteEmployee(int id)
        {
            using(var c = new Context())
            {
                var values = c.Employees.Find(id);
                if( values == null)
                {
                    return NotFound();
                }
                else
                {
                    c.Employees.Remove(values);
                    c.SaveChanges() ;
                }
                return Ok("Silme işlemi başariyle silindi");
            }
        }
        [HttpPut]
        public IActionResult EmployeeUpdate(Employee p)
        {
            using(var c = new Context())
            {
                var values = c.Find<Employee>(p.EmployeeID);
                if(values == null)
                {
                    return NotFound();
                }
                else
                {
                    values.EmployeeName = p.EmployeeName;
                    c.Update(values);
                    c.SaveChanges() ;
                    return Ok("Güncelleme başarılı bir sekilde güncellendi");

                }
            }
        }
    }
}
