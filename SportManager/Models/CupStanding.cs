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
        public List<CupRound> cupRound { get; set; }


        public void start(Collection<Team> teams)
        {
            int numberOfTeams = teams.Count;

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
