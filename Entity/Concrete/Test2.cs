using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Test2
    {
        [Key]
        public int TestID  { get; set; }
        public string TestName  { get; set; }
    }
}
