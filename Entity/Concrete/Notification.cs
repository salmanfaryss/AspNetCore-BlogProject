using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Notification
    {
        [Key]
        public int NotificationID { get; set; }
        public string NotificationType { get; set; }
        public string NotificationSymbole { get; set; }
        public string NotificationContent { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
