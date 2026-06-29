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
    public class NotificationManager : INotificationService
    {
        INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void TDelete(Notification p)
        {
            _notificationDal.Delete(p);
        }

        public List<Notification> TGet6Notification()
        {
            return _notificationDal.Get6Notification();
        }

        public Notification TGetByID(int id)
        {
            return _notificationDal.GetByID(id);
        }

        public List<Notification> TGetList()
        {
           return _notificationDal.GetList();
        }

        public void TInsert(Notification p)
        {
            _notificationDal.Insert(p);
        }

        public void TUpdate(Notification p)
        {
           _notificationDal.Update(p);
        }
    }
}
