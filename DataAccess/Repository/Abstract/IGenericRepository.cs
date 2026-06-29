using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Abstract
{
    public interface IGenericRepository<T>
    {
        List<T> GetList();
        void Update(T p);
        void Delete(T p);
        void Insert(T p);
        T GetByID (int id);

        List<T> List(Expression<Func<T, bool>> filter);
        T Get(Expression<Func<T, bool>> filter);

    }
}
