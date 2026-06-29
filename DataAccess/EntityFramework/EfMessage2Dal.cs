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
    public class EfMessage2Dal : GenericRepository<Message2>, IMessage2Dal
    {
        public void ChangeStatusToTrue(Message2 p)
        {
            p.IsReady = true;
        }

        public List<Message2> GetListInboxMessageByWriter(int id)
        {
            Context c = new Context();
           
            return c.message2.Where(x => x.ReceiverID == id).Include(x => x.ReceiverUser).Include(x => x.SenderUser).ToList();

            ////return c.message2.Include(x => x.ReceiverUser).Where(y => y.SenderID ==id).ToList();
        }

        public List<Message2> GetListSendMessageByWriter(int id)
        {
            Context c = new Context();
            return  c.message2.Where(x => x.SenderID == id).Include(x => x.ReceiverUser).Include(x => x.ReceiverUser).ToList();

            //return c.message2.Include(x => x.SenderUser).Where(y => y.ReceiverID == id).ToList();
        }

        public List<Message2> GetListWithUsers()
        {
           Context c = new Context();
            return c.message2.Include(x => x.SenderUser).Include(y => y.ReceiverUser).ToList();
        }

        public int InboxMessageCount(int id)
        {
            Context c = new Context();

            return c.message2.Where(x => x.ReceiverID == id).Include(x => x.ReceiverUser).Include(x => x.SenderUser).Count();

        }

        public int SendboxMessageCount(int id)
        {
            Context c = new Context();

            return c.message2.Where(x => x.SenderID == id).Include(x => x.ReceiverUser).Include(x => x.SenderUser).Count();

        }
    }
}
