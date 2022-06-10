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
        public DateTime startDate { get; set; } = DateTime.Now;
        public TournamentStatus status { get; set; } = TournamentStatus.NOT_STARTED;
        public string type = "League";
        public LeagueStanding league { get; set; }
        public CupStanding cup { get; set; }
        public Collection<Team> teams { get; set; } = new Collection<Team>();
        public int numberOfTeams { get; set; }


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

        public Tournament(int id, string title, DateTime start,int numberOfTeams, TournamentStatus status,LeagueStanding league,CupStanding cup,string type)
        {
            this.type = type;
            this.id = id;
            this.title = title;
            this.startDate = start;
            this.status = status;
            this.league = league;
            this.teams = new Collection<Team>();
            this.cup = cup;
            this.numberOfTeams = numberOfTeams;
        }

        public void startTournament(System.Windows.Controls.ListBox matchesListbox)
        {
            status = TournamentStatus.IN_PRROGRESS;

            if (type == "Cup")
            {
                cup.start(teams);
            }
            else
            {
                league.start(teams, matchesListbox);
            }
        }

        


    }
}
