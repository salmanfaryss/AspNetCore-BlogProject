using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Abstract
{
    public interface IBlogService:IGenericService<Blog>
    {
        //List<Blog> TGetList();
        //void TUpdate(Blog p);
        //void TDelete(Blog p);
        //void TInsert(Blog p);
        //Blog TGetByID(int id);
        int TCategoryBlogCount(int id);
        List<Blog> TGetBlogWithCategoryWithWriter();
        void TChangeBlogStatusToTrue(Blog p);
        void TChangeBlogStatusToFalse(Blog p);
        List<Blog> TGetListWithCategoryByWriter(int id);

        int TTotalBlogCount();
        int TLast7DayBlogCount();
        //int TTotalCategoryCount();
        int TWriterTotalBlogCount(int id);
    }
}
