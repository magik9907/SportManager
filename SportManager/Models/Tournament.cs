using SportManager.Models.enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportManager.Models
{
    public class Tournament
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime startDate { get; set; }
        public TournamentStatus status { get; set; }
        public LeagueStanding league { get; set; }
        public Collection<Team> teams { get; set; }

        public String Status
        {
            get
            {
                switch (status)
                {
                    case TournamentStatus.DONE: return "Done";
                    case TournamentStatus.IN_PRROGRESS: return "In progress";
                    case TournamentStatus.NOT_STARTED: return "Not started";
                }
                return "Unknown";
            }
        }

        public Tournament()
        {
        }

        public Tournament(int id, string title, DateTime start, TournamentStatus status,LeagueStanding league)
        {
            this.id = id;
            this.title = title;
            this.startDate = start;
            this.status = status;
            this.league = league;
        }


    }
}
