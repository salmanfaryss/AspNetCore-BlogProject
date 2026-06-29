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
    public class ToDoManager : ITodoService
    {
        IToDoDal _toDal;

        public ToDoManager(IToDoDal toDal)
        {
            _toDal = toDal;
        }

        public void TDelete(ToDo p)
        {
            _toDal.Delete(p);
        }

        public ToDo TGetByID(int id)
        {
           return _toDal.GetByID(id);
        }

        public List<ToDo> TGetList()
        {
            return _toDal.GetList();
        }

        public void TInsert(ToDo p)
        {
            _toDal.Insert(p);
        }

        public void TUpdate(ToDo p)
        {
           _toDal.Update(p);
        }
    }
}
