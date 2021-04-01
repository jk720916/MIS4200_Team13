using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS4200_Team13.Models
{
    public class Scoreboard
    {
        public int scoreBoardID { get; set; }
        public virtual profileData fullName { get; set; }
        public virtual award awards { get; set; }
        public string name {get; set;}
        }
}