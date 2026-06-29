using DataAccess.Repository.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICommentDal:IGenericRepository<Comment>
    {
        List<Comment> GetCommentWithBlog();
        //List<Comment> TGetCommentByBlog();

        List<Comment> GetCommentWithoutBlog();
        
    }
}
