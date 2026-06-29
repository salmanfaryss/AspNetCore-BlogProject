using DataAccess.Dtos;
using DataAccess.Repository.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICategoryDal:IGenericRepository<Category>
    {
        List<Category> TGet4List();
        int TotalCategoryCount();
        List<CategoryBlogCountDto> categoryBlogCountDtos();

        void ChangeStatusToTrue(Category p);
        void ChangeStatusToFalse(Category p);

        
    }
}
