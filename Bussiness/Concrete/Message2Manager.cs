using Bussiness.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Concrete
{
    public class Message2Manager : IMessage2Service
    {
        IMessage2Dal _message2Dal;
        Context c = new Context();

        public Message2Manager(IMessage2Dal message2Dal)
        {
            _message2Dal = message2Dal;
        }

        public List<Message2> GetInboxListByWriter(int id)
        {
            return _message2Dal.GetListInboxMessageByWriter(id);
        }

        public Message2 GetMessageDetail(int id)
        {
            return c.message2
         .Include(x => x.SenderUser)
         .Include(x => x.ReceiverUser)
         .FirstOrDefault(x => x.MessageID == id);
        }

        public List<Message2> GetSenboxListByWriter(int id)
        {
            return _message2Dal.GetListSendMessageByWriter(id);
        }

        public int InboxMessageCount(int id)
        {
            return _message2Dal.InboxMessageCount(id);
        }

        public int SendboxMessageCount(int id)
        {
           return _message2Dal.SendboxMessageCount(id);
        }

        public void TChangeStatusToTrue(Message2 p)
        {
            _message2Dal.ChangeStatusToTrue(p);
            _message2Dal.Update(p);
        }

        public void TDelete(Message2 p)
        {
           _message2Dal.Delete(p);
        }

        public Message2 TGetByID(int id)
        {
           return _message2Dal.GetByID(id);
        }

        public List<Message2> TGetList()
        {
            return _message2Dal.GetList();
        }

        public List<Message2> TGetListWithUsers()
        {
            return _message2Dal.GetListWithUsers();
        }

        public void TInsert(Message2 p)
        {
           _message2Dal.Insert(p);
        }

        public void TUpdate(Message2 p)
        {
            _message2Dal.Update(p);
        }
    }
}
