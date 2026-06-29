using DataAccess.Abstract;
using DataAccess.Repository.Concrete;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfMessageDal:GenericRepository<Message>,IMessageDal
    {
    }
}
