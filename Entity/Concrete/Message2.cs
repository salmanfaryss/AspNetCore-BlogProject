using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Message2
    {
        [Key]
        public int MessageID { get; set; }
        public int? SenderID { get; set; }
        public int? ReceiverID { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public bool IsReady { get; set; }
        public DateTime Date { get; set; }

        public Writer SenderUser { get; set; }
        public Writer ReceiverUser { get; set; }
    }
}
