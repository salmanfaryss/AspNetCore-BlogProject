using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repository.Concrete;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfBlogDal : GenericRepository<Blog>, IBlogDal
    {
       
        public void ChangeBlogStatusToFalse(Blog p)
        {
            p.Status = false;
        }

        public void ChangeBlogStatusToTrue(Blog p)
        {
           p.Status = true;
        }

        public List<Blog> GetBlogWithCategory()
        {
            Context c = new Context();

            return  c.blogs.Include(b => b.Category).ToList();

        }

        public List<Blog> GetBlogWithCategoryWithWriter()
        {
            Context c = new Context();
            return c.blogs.Include(x => x.Category).Include(y => y.Writer).ToList();
        }

        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            Context c =new Context();
            return c.blogs.Include(x => x.Category).Where(y => y.WriterID == id).ToList();
        }

        public int Last7DayBlogCount()
        {
            throw new NotImplementedException();
        }

        public List<Blog> TGetBlogListByWriter(int id)
        {
          Context c = new Context();
         return c.blogs.Where(x => x.BlogID == id).ToList();
        }

        //public List<Blog> TGetBlogListWithCategory()
        //{
        //    throw new NotImplementedException();
        //}

        public List<Blog> TGetLast3Blog()
        {
            Context c = new Context();
            return c.blogs.Take(3).ToList();
        }

        public int TotalBlogCount()
        {
            Context c =new Context();
            return c.blogs.Count();
        }

        public int WriterTotalBlogCount(int id)
        {
            Context ctx = new Context();
            return ctx.blogs.Where(x => x.WriterID ==id).Count();
        }
    }
}
