using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportManager.Models
{
    public class Match
    {
        public Team host { get; set; }
        public Team guest { get; set; }
        public int host_goal { get; set; }
        public int guest_goal { get; set; }
        /**
         * 1 if winner is host
         * 0 if winner is guest
         */
        public bool winner { get; set; }
    }
}
