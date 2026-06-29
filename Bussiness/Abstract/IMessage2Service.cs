using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Abstract
{
    public interface IMessage2Service:IGenericService<Message2>
    {
        List<Message2> GetInboxListByWriter(int id);
        List<Message2> GetSenboxListByWriter(int id);
        void TChangeStatusToTrue(Message2 p);
        List<Message2> TGetListWithUsers();
        int InboxMessageCount(int id);
        int SendboxMessageCount(int id);

        Message2 GetMessageDetail(int id);
    }
}
