﻿using System;
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
        public int host_yellowcard { get; set; }
        public int guest_yellowcard { get; set; }
        public int host_redcard { get; set; }
        public int guest_redcard { get; set; }



        /**
         * true if winner is host
         * false if winner is guest
         */
        public bool winner { get; set; }

        /**
        * true if match ended
        * false if match didn't end
        */
        public bool matchEnded { get; set; }
    }
}
