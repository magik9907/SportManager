using SportManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace SportManager
{
    /// <summary>
    /// Logika interakcji dla klasy MatchDetails.xaml
    /// </summary>
    public partial class MatchDetails : Window
    {
        public Match match { get; set; }

        private Collection<Team> teams;
        public MatchDetails(Match match, Collection<Team> teams)
        {
            InitializeComponent();
            this.match = match;
            this.Who.Text = match.host.name + " VS " + match.guest.name;
            this.teams = new Collection<Team>();
            //foreach (Team team in teams)
            //{
            //    if (tournament.teams != null && !tournament.teams.Contains(team))
            //    {
            //        this.teams.Add(team);
            //    }
            //}

            //allTeamsListBox.ItemsSource = this.teams;
            //participatingTeamsListBox.ItemsSource = tournament.teams;

            //stateInitWindow();
        }

        private void ChangeHost()
        {
            
        }

        public MatchDetails()
        {
            InitializeComponent();
        }

        private void Gol_1(object sender, RoutedEventArgs e)
        {
        }
        private void YellowCard_1(object sender, RoutedEventArgs e)
        {
        }
        private void RedCard_1(object sender, RoutedEventArgs e)
        {
        }
        private void Gol_2(object sender, RoutedEventArgs e)
        {
        }
        private void YellowCard_2(object sender, RoutedEventArgs e)
        {
        }
        private void RedCard_2(object sender, RoutedEventArgs e)
        {
        }



        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            match.guest_goal = 3;
            match.host_goal = 0;
            match.winner = false;
        }
    }
}
