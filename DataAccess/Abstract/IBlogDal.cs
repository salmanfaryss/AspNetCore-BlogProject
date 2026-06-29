using DataAccess.Repository.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IBlogDal:IGenericRepository<Blog>
    {
       
        List<Blog> GetBlogWithCategory();
        List<Blog> GetBlogWithCategoryWithWriter();
        List<Blog> TGetLast3Blog();
     //   List<Blog> TGetBlogListWithCategory();
        List<Blog> TGetBlogListByWriter(int id);
        List<Blog>GetListWithCategoryByWriter(int p);

        void ChangeBlogStatusToTrue(Blog p);
        void ChangeBlogStatusToFalse(Blog p);

        int TotalBlogCount();
        int Last7DayBlogCount();
       
        int WriterTotalBlogCount(int id);
    }
}
