using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{

    public enum PriorityLevel
    {
        Low = 1,
        Medium = 2,
        High = 3,
        Urgent = 4
    }

    public class ToDo
    {
        [Key]
        public int ToDoID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string? ProcessDescription { get; set; }
        public PriorityLevel Priority { get; set; } = PriorityLevel.Medium;
        public bool Status { get; set; }
        
        public List<ToDosLogs> ToDosLogs { get; set; }

    }
}
