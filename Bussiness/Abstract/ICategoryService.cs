using DataAccess.Dtos;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Abstract
{
    public interface ICategoryService:IGenericService<Category>
    {
        //List<Category> TGetList();

        //public void TCategoryBlgoCount();
        List<CategoryBlogCountDto> TcategoryBlogCountDtos();
        List<Category> TGet4List();
        //void TUpdate(Category p);
        //void TDelete(Category p);
        //void TInsert(Category p);
        //Category TGetByID(int id);
        int TCategoryCount();
        void TChangeStatusToTrue(Category p);
        void TChangeStatusToFalse(Category p);
    }
}
