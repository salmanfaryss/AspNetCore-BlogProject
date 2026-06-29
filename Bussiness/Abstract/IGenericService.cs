using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Abstract
{
    public interface IGenericService<T>
    {
        List<T> TGetList();
      
        void TUpdate(T p);
        void TDelete(T p);
        void TInsert(T p);
        T TGetByID(int id);

       
    }
}
