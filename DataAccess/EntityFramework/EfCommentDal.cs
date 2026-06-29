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
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> GetCommentWithBlog()
        {
            Context c = new Context();

            return c.comments.Include(x => x.Blog).ToList();
        }

        public List<Comment> GetCommentWithoutBlog()
        {
            Context c = new Context();
            return c.comments.Include(c => c.Blog).ToList();
        }
    }
}
