using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace SportManager.Models
{
    public class LeagueStanding
    {
        public List<TeamStats> rank { get; set; } = new List<TeamStats>();

        public class TeamStats
        {
            public int lp { get; set; }
            public Team team { get; set; }
            public int points { get; set; }
            public int win { get; set; }
            public int draw { get; set; }
            public int loose { get; set; }
            public int goal_for { get; set; }
            public int goal_against { get; set; }

        }

        public void start(Collection<Team> teams)
        {

        }


        public void mock()
        {
            rank.Add(new TeamStats()
            {
                lp = 1,points=20,
                win = 3,
                draw = 4,
                loose = 2,
                goal_against = 33,
                goal_for = 20,
                team = new Team()
                {
                    name = "Team 1"
                }
            });
            rank.Add(new TeamStats()
            {
                lp = 2
          ,
                points = 20,
                win = 3,
                draw = 4,
                loose = 2,
                goal_against = 33,
                goal_for = 20,
                team = new Team()
                {
                    name = "Team 2"
                }
            });
            rank.Add(new TeamStats()
            {
                lp = 3
          ,
                points = 20,
                win = 3,
                draw = 4,
                loose = 2,
                goal_against = 33,
                goal_for = 20,
                team = new Team()
                {
                    name = "Team 3"
                }
            });
        }
    }
}
