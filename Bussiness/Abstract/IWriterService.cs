using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Abstract
{
    public interface IWriterService:IGenericService<Writer>
    {
        //List<Writer> TGetList();
        //void TUpdate(Writer p);
        //void TDelete(Writer p);
        //void TInsert(Writer p);
        //Writer TGetByID(int id);

        List<Writer> TGetWriterByID(int id);
    }
}
