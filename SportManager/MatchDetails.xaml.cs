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
           

            //string ScoreHost = To_Str(match.host_goal), ScoreGuest = To_Str(match.guest_goal), YellowHost="0", YellowGuest="0", RedHost="0", RedGuest="0";

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


        public MatchDetails()
        {
            InitializeComponent();
        }

        public string To_Str(int i)
        {
            string str = i.ToString();
            return str;
        }
        public int To_Int(string str)
        {
            int i = Int32.Parse(str);
            return i;
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            Gol_1.Text = To_Str(match.host_goal);
            Gol_2.Text = To_Str(match.guest_goal);
            YellowCard_1.Text = To_Str(match.host_yellowcard);
            YellowCard_2.Text = To_Str(match.guest_yellowcard);
            RedCard_1.Text = To_Str(match.host_redcard);
            RedCard_2.Text = To_Str(match.guest_redcard);
        }


        //private void Gol_1(object sender, RoutedEventArgs e)
        //{
        //}
        //private void YellowCard_1(object sender, RoutedEventArgs e)
        //{
        //}
        //private void RedCard_1(object sender, RoutedEventArgs e)
        //{
        //}
        //private void Gol_2(object sender, RoutedEventArgs e)
        //{
        //}
        //private void YellowCard_2(object sender, RoutedEventArgs e)
        //{
        //}
        //private void RedCard_2(object sender, RoutedEventArgs e)
        //{
        //}



        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            match.host_goal = To_Int(Gol_1.Text);
            match.guest_goal = To_Int(Gol_2.Text);
            match.host_yellowcard = To_Int(YellowCard_1.Text);
            match.guest_yellowcard = To_Int(YellowCard_2.Text);
            match.host_redcard = To_Int(RedCard_1.Text);
            match.guest_redcard = To_Int(RedCard_2.Text);

            if (match.guest_goal> match.host_goal) match.winner = false;
        }
    }
}
