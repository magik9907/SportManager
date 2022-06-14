using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportManager.Models
{
    public class CupRound
    {
        public List<Match> matches { get; set; } = new List<Match>();

        public CupRound() { }

    }

    public class CupStanding
    {
        /**
         * List of round 
         * index is pow of 2 for round description
         * example
         * final == round 1/1 for index 0 (2^0)=1
         * semi-finals = round 1/2 for index 1 (2^1)=2
         * quarte-finals = round 1/4 for index 2 (2^2)=4 ... etc.
         */
        public List<CupRound> cupRound { get; set; } = new List<CupRound>();


        public void start(Collection<Team> teams)
        {
            var random = new Random();
            int numberOfTeams = teams.Count;
            CupRound round = null;

            for (int i = 0; i <= Math.Floor(Math.Sqrt(numberOfTeams)); i++)
            {
                round = new CupRound();
                round.matches.Capacity = (int)Math.Pow(2, i);
                cupRound.Add(round);
            }
            var teamsIndexes = Enumerable.Range(0, numberOfTeams).ToList();
            for (int i = 0; i < Math.Floor((double)numberOfTeams / 2); i++)
            {
                var match = new Match();
                int rand = random.Next(0, teamsIndexes.Count());
                match.host = teams[teamsIndexes[rand]];
                teamsIndexes.RemoveAt(rand);
                rand = random.Next(0, teamsIndexes.Count());
                match.guest = teams[teamsIndexes[rand]];
                teamsIndexes.RemoveAt(rand);
                round.matches.Add(match);
            }

            if (teamsIndexes.Count == 1)
            {
                var match = new Match();
                match.host = teams[teamsIndexes[0]];
                round.matches.Add(match);
                int size = round.matches.Count;
                round = cupRound[(int)Math.Floor(Math.Sqrt(numberOfTeams)) - 1];
                var m = new Match();
                if (size % 4 > 1)
                    m.guest = match.host;
                else m.host = match.host;
                round.matches.Insert((int)Math.Floor((double)size / 2) - 1, m);

            }
        }

        //Example data
        public void mock()
        {
            cupRound = new List<CupRound>()
            {
                new CupRound(),
                new CupRound()
                {
                    matches = new List<Match>()
                    {
                        new Match()
                        {
                            host = new Team(){name="team 4"},
                        },
                        new Match()
                        {
                            host = new Team(){name="team 6"},
                        }
                    }
                },
                new CupRound()
                {
                    matches = new List<Match>()
                    {
                        new Match()
                        {
                            guest = new Team(){name="team 1"},
                            host = new Team(){name="team 2"},
                        },
                        new Match()
                        {
                            guest = new Team(){name="team 3"},
                            host = new Team(){name="team 4"},
                            guest_goal=3,
                            host_goal=1,
                            winner = false
                        },
                        new Match()
                        {
                            guest = new Team(){name="team 5"},
                            host = new Team(){name="team 6"},
                            guest_goal=2,
                            host_goal=5,
                            winner = true
                        }
                    }
                },
                new CupRound()
                {
                    matches = new List<Match>()
                    {
                        new Match()
                        {
                            guest = new Team(){name="team 1"},
                            host = new Team(){name="team 2"},
                        },
                        new Match()
                        {
                            guest = new Team(){name="team 3"},
                            host = new Team(){name="team 4"},
                            guest_goal=3,
                            host_goal=1,
                            winner = false
                        },
                        new Match()
                        {
                            guest = new Team(){name="team 5"},
                            host = new Team(){name="team 6"},
                            guest_goal=2,
                            host_goal=5,
                            winner = true
                        }
                    }
                },
                new CupRound()
                {
                    matches = new List<Match>()
                    {
                        new Match()
                        {
                            guest = new Team(){name="team 1"},
                            host = new Team(){name="team 2"},
                        },
                        new Match()
                        {
                            guest = new Team(){name="team 3"},
                            host = new Team(){name="team 4"},
                            guest_goal=3,
                            host_goal=1,
                            winner = false
                        },
                        new Match()
                        {
                            guest = new Team(){name="team 5"},
                            host = new Team(){name="team 6"},
                            guest_goal=2,
                            host_goal=5,
                            winner = true
                        }
                    }
                },
                new CupRound()
                {
                    matches = new List<Match>()
                    {
                        new Match()
                        {
                            guest = new Team(){name="team 1"},
                            host = new Team(){name="team 2"},
                        },
                        new Match()
                        {
                            guest = new Team(){name="team 3"},
                            host = new Team(){name="team 4"},
                            guest_goal=3,
                            host_goal=1,
                            winner = false
                        },
                        new Match()
                        {
                            guest = new Team(){name="team 5"},
                            host = new Team(){name="team 6"},
                            guest_goal=2,
                            host_goal=5,
                            winner = true
                        }
                    }
                },
                new CupRound()
                {
                    matches = new List<Match>()
                    {
                        new Match()
                        {
                            guest = new Team(){name="team 1"},
                            host = new Team(){name="team 2"},
                        },
                        new Match()
                        {
                            guest = new Team(){name="team 3"},
                            host = new Team(){name="team 4"},
                            guest_goal=3,
                            host_goal=1,
                            winner = false
                        },
                        new Match()
                        {
                            guest = new Team(){name="team 5"},
                            host = new Team(){name="team 6"},
                            guest_goal=2,
                            host_goal=5,
                            winner = true
                        },
                        new Match()
                        {
                            guest = new Team(){name="team 5"},
                            host = new Team(){name="team 6"},
                            guest_goal=2,
                            host_goal=5,
                            winner = true
                        },
                        new Match()
                        {
                            guest = new Team(){name="team 5"},
                            host = new Team(){name="team 6"},
                            guest_goal=2,
                            host_goal=5,
                            winner = true
                        },
                        new Match()
                        {
                            guest = new Team(){name="team 5"},
                            host = new Team(){name="team 6"},
                            guest_goal=2,
                            host_goal=5,
                            winner = true
                        },
                        new Match()
                        {
                            guest = new Team(){name="team 5"},
                            host = new Team(){name="team 6"},
                            guest_goal=2,
                            host_goal=5,
                            winner = true
                        },
                        new Match()
                        {
                            guest = new Team(){name="team 5"},
                            host = new Team(){name="team 6"},
                            guest_goal=2,
                            host_goal=5,
                            winner = true
                        },
                        new Match()
                        {
                            guest = new Team(){name="team 5"},
                            host = new Team(){name="team 6"},
                            guest_goal=2,
                            host_goal=5,
                            winner = true
                        }
                    }
                }

            };

        }
    }


}
