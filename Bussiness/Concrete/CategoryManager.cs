using Bussiness.Abstract;
using DataAccess.Abstract;
using DataAccess.Dtos;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        

        public List<CategoryBlogCountDto> TcategoryBlogCountDtos()
        {
            return _categoryDal.categoryBlogCountDtos();
        }

        public int TCategoryCount()
        {
            return _categoryDal.TotalCategoryCount();
        }

        public void TChangeStatusToFalse(Category p)
        {
            _categoryDal.ChangeStatusToFalse(p);
            _categoryDal.Update(p);
            
        }

        public void TChangeStatusToTrue(Category p)
        {
           _categoryDal.ChangeStatusToTrue(p);
            _categoryDal.Update(p);
        }

        public void TDelete(Category p)
        {
           _categoryDal.Delete(p);
        }

        public List<Category> TGet4List()
        {
           return _categoryDal.TGet4List();
        }

        public Category TGetByID(int id)
        {
            return _categoryDal.GetByID(id);
        }

        public List<Category> TGetList()
        {
            return _categoryDal.GetList();
        }

        public void TInsert(Category p)
        {
           _categoryDal.Insert(p);
        }

        public void TUpdate(Category p)
        {
            _categoryDal.Update(p);
        }
    }
}
