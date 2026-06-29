using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public string CommentUserName { get; set; }
        public string CommentTitle { get; set; }
        public string CommentContent { get; set; }
        public DateTime Date {  get; set; }
        public bool Status { get; set; }
        public string CommentUserImage { get; set; }
        public int BlogScore { get; set; }
       
        public int BlogID { get; set; }
        public Blog Blog { get; set; }
    }
}
