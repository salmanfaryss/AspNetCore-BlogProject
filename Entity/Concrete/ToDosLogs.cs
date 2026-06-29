using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class ToDosLogs
    {
        [Key]
        public int LogId { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }

        public int ToDoID { get; set; }
        public  ToDo ToDo { get; set; }
    }
}
