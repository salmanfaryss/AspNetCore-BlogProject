using DataAccess.Repository.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IMessage2Dal:IGenericRepository<Message2>
    {
        List<Message2> GetListInboxMessageByWriter(int id);
        List<Message2> GetListSendMessageByWriter(int id);
        int InboxMessageCount (int id);
        int SendboxMessageCount(int id);
        List<Message2> GetListWithUsers();
        void ChangeStatusToTrue(Message2 p);
    }
}
