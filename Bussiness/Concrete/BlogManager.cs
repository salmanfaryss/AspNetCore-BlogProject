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
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public int TCategoryBlogCount(int id)
        {

          return _blogDal.List(x => x.CategoryID == id).Count();
        }

        public void TChangeBlogStatusToFalse(Blog p)
        {
            _blogDal.ChangeBlogStatusToFalse(p);
            _blogDal.Update(p);
        }

        public void TChangeBlogStatusToTrue(Blog p)
        {
           _blogDal.ChangeBlogStatusToTrue(p);
            _blogDal.Update(p);
        }

        public void TDelete(Blog p)
        {
            _blogDal.Delete(p);
        }

        public List<Blog> TGetBlogListByWriter(int id)
        {
            return _blogDal.List(x => x.WriterID == id);
        }

        public List<Blog> TGetBlogListWithCategory()
        {
           return _blogDal.GetBlogWithCategory().Take(5).ToList();
        }

        public List<Blog> TGetBlogWithCategoryWithWriter()
        {
            return _blogDal.GetBlogWithCategoryWithWriter().ToList();
        }

        public Blog TGetByID(int id)
        {
           return _blogDal.GetByID(id);
        }

        public List<Blog> TGetLast3Blog()
        {
            return _blogDal.GetList().Take(3).ToList();
        }

        public List<Blog> TGetList()
        {
           return _blogDal.GetList();
        }

        public List<Blog> TGetListWithCategoryByWriter(int id)
        {
            return _blogDal.GetListWithCategoryByWriter(id);
        }

        public void TInsert(Blog p)
        {
            _blogDal.Insert(p);
        }

        public int TLast7DayBlogCount()
        {
            throw new NotImplementedException();
        }

        public int TTotalBlogCount()
        {
          return _blogDal.TotalBlogCount();
        }

       

        public void TUpdate(Blog p)
        {
           _blogDal.Update(p);
        }

        public int TWriterTotalBlogCount(int id)
        {
          return _blogDal.WriterTotalBlogCount(id);
        }
    }
}
