using Bussiness.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void TDelete(Comment p)
        {
            _commentDal.Delete(p);
        }

        public Comment TGetByID(int id)
        {
           return _commentDal.GetByID(id);
        }

        public List<Comment> TGetCommentByBlog()
        {
            return _commentDal.GetCommentWithBlog();
        }

        public List<Comment> TGetCommentWithoutBlog()
        {
           return _commentDal.GetCommentWithoutBlog();
        }

        public List<Comment> TGetList(int id)
        {
            return _commentDal.List(x => x.BlogID ==id);
        }

        public List<Comment> TGetList()
        {
            return _commentDal.GetList();
        }

        public void TInsert(Comment p)
        {
           _commentDal.Insert(p);
        }

        public void TUpdate(Comment p)
        {
           _commentDal.Update(p);
        }
    }
}
