using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }
        public string SenderEmail { get; set; }
        public string ReceiverEmail {  get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string IsReady { get; set; }
        public DateTime Date {  get; set; }

    }
}
