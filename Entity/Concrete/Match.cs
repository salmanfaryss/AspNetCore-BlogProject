using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Match
    {
        [Key]
        public int MatchID { get; set; }
        public int? HomeTeamID { get; set; }
        public int? GuestTeamdID { get; set; }
        public string MatchDate { get; set; }
        public string Stdium {  get; set; }

        //public int TeamID { get; set; }
        public Team HomeTeam { get; set; }
        public Team GuestTeam { get; set; }
    }
}
