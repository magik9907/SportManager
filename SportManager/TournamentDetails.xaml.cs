using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SportManager.Models;
using System.Collections.ObjectModel;

namespace SportManager
{
    /// <summary>
    /// Logika interakcji dla klasy TournamentDetails.xaml
    /// </summary>
    public partial class TournamentDetails : Window
    {
        public Tournament tournament;
        private Collection<Team> teams;

        public TournamentDetails(Tournament tournament, Collection<Team> teams)
        {
            InitializeComponent();
            this.tournament = tournament;
            this.title.Text = tournament.title;
            this.teams = new Collection<Team>();
            foreach(Team team in teams)
            {
                if(!tournament.teams.Contains(team))
                {
                    this.teams.Add(team);
                }
            }
            leagueStandingView.ItemsSource = tournament.league.rank;
            allTeamsListBox.ItemsSource = this.teams;
            participatingTeamsListBox.ItemsSource = tournament.teams;

            
            

        }
        public void clickAddTeam(object sender, RoutedEventArgs e)
        {
            tournament.teams.Add(teams.ElementAt(allTeamsListBox.SelectedIndex));
            this.teams.Remove(teams.ElementAt(allTeamsListBox.SelectedIndex));
            participatingTeamsListBox.Items.Refresh();
            allTeamsListBox.Items.Refresh();
        }
        public void clickRemoveTeam(object sender, RoutedEventArgs e)
        {
            teams.Add(tournament.teams.ElementAt(participatingTeamsListBox.SelectedIndex));
            tournament.teams.Remove(tournament.teams.ElementAt(participatingTeamsListBox.SelectedIndex));
            participatingTeamsListBox.Items.Refresh();
            allTeamsListBox.Items.Refresh();

        }
    }
}
