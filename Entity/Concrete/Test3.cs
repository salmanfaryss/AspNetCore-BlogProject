using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Test3
    {
        [Key]
        public int Test3ID { get; set; }
        public string Test3Name { get; set; }
    }
}
