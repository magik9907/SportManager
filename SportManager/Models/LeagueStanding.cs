﻿using System;
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
        public Collection<Match> matches { get; set; } = new Collection<Match>();

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

            public TeamStats(int lp, Team team, int points, int win, int draw, int loose, int goal_for, int goal_against)
            {
                this.lp = lp;
                this.team = team;
                this.points = points;
                this.win = win;
                this.draw = draw;
                this.loose = loose;
                this.goal_for = goal_for;
                this.goal_against = goal_against;

            }
            public TeamStats()
            {

            }


        }

        public void start(Collection<Team> teams, System.Windows.Controls.ListBox matchesListBox)
        {
            for (int i = 0; i < teams.Count; i++)
            {
                for (int j = 0; j < teams.Count; j++)
                {
                    if (i < j)
                    {

                        matches.Add(new Match { guest = teams.ElementAt(j), host = teams.ElementAt(i) });
                        matches.Add(new Match { guest = teams.ElementAt(i), host = teams.ElementAt(j) });
                    }
                }
                rank.Add(new TeamStats(i + 1, teams.ElementAt(i), 0, 0, 0, 0, 0, 0));


            }
            matchesListBox.ItemsSource = matches;
            System.Diagnostics.Debug.WriteLine(teams.Count);
        }


        public void mock()
        {
            rank.Add(new TeamStats()
            {
                lp = 1,
                points = 20,
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
