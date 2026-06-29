using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterID { get; set; }
        public string WriterName { get; set; }
        public string WriterImage {  get; set; }
       
        public string WriterAbout { get; set; }
        public string WriterAboutDetail { get; set; }
        public string WriterAdres { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }


        public List<Blog> Blogs { get; set; }
        public virtual ICollection<Message2> writerSenderMessage { get; set; }
        public virtual ICollection<Message2> writerReceiverMessage { get; set; }




    }
}
