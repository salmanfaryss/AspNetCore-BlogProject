using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Abstract
{
    public interface ICommentService:IGenericService<Comment>
    {
        //List<Comment> TGetList();
        //void TUpdate(Comment p);
        //void TDelete(Comment p);
        //void TInsert(Comment p);
        //Comment TGetByID(int id);

        List<Comment> TGetCommentWithoutBlog();





    }
}
