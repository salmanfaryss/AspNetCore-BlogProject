using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repository.Concrete;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfAppRoleDal : GenericRepository<AppRole>, IAppRoleDal
    {
        Context c = new Context();

        public Task<List<AppRole>> GetUserWithRole()
        {
            throw new NotImplementedException();
        }
      
    }
}
