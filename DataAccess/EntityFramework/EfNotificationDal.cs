using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repository.Concrete;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        Context c = new Context();
        public List<Notification> Get6Notification()
        {
            return c.notification.Take(6).ToList();
        }
    }
}
