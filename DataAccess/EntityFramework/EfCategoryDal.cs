using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Dtos;
using DataAccess.Repository.Concrete;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        Context c = new Context();

        public List<CategoryBlogCountDto> categoryBlogCountDtos()
        {

            var values = c.blogs
       .GroupBy(x => x.CategoryID)
       .Select(g => new CategoryBlogCountDto
       {
           CategoryName = c.categories
               .Where(ca => ca.CategoryID == g.Key)
               .Select(ca => ca.CategoryName)
               .FirstOrDefault(),

           BlogCount = g.Count()
       }).ToList();

            return values;
           
        }

        public void ChangeStatusToFalse(Category p)
        {
           p.Status =false;
           
        }

        public void ChangeStatusToTrue(Category p)
        {
            p.Status=true;
        }

        public List<Category> TGet4List()
        {
           Context c = new Context();
            return c.categories.Take(4).ToList();
        }
        public int TotalCategoryCount()
        {
            Context c = new Context();
          return  c.categories.Count();
        }

       
    }
}
