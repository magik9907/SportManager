using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportManager.Models
{
    public class Player
    {
        public string fullName { get; set; }
        public string position { get; set; }
        public bool isCaptain { get; set; }
        public bool substitute { get; set; }
    }
}
