using SportManager.Models;
using SportManager.Models.enums;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace SportManager
{
    public partial class MainWindow : Window
    {
        private List<Tournament> tournaments = new List<Tournament>();
        public Collection<Team> teams = new Collection<Team>();

        public MainWindow()
        {
            InitializeComponent();
            tournametsList.ItemsSource = tournaments;

            //TODO delete mock

            CupStanding cup = new CupStanding();
            cup.mock();

            LeagueStanding league = new LeagueStanding();

            league.mock();

            tournaments.AddRange(new[] {
                new Tournament(1, "Tournament 1", DateTime.Parse("2022-01-11"), TournamentStatus.NOT_STARTED,league,cup),
        new Tournament(2, "Tournament 2", DateTime.Parse("2022-11-22"), TournamentStatus.IN_PRROGRESS,league,cup),
        new Tournament(3, "Tournament 3", DateTime.Parse("2022-03-11"), TournamentStatus.NOT_STARTED,league,cup),
        new Tournament(4, "Tournament 4", DateTime.Parse("2022-06-22"), TournamentStatus.DONE,league,cup),
        new Tournament(5, "Tournament 5", DateTime.Parse("2022-05-11"), TournamentStatus.NOT_STARTED,league,cup)
       });

           

        }

        private void Create_Tournament(object sender, RoutedEventArgs e)
        {
            CreateTournament create = new CreateTournament();
            if(true == create.ShowDialog())
            {

            }
        }
     

        private void showTournament(object sender, SelectionChangedEventArgs e)
        {
            Tournament tournament = tournaments.ElementAt(tournametsList.SelectedIndex);
            TournamentDetails tournamentDetails = new TournamentDetails(tournament, teams);
            if (true == tournamentDetails.ShowDialog())
            {

            }
        }
        private void createTeam(object sender, RoutedEventArgs e)
        {
            CreateTeam createTeam = new CreateTeam();
            if(true == createTeam.ShowDialog())
            {
                Team team = new Team(teams.Count(), createTeam.nameBox.Text, createTeam.streetNameBox.Text, createTeam.streetNumberBox.Text, createTeam.postalCodeBox.Text, createTeam.cityBox.Text, (BitmapImage)createTeam.imgPhoto.Source);
                teams.Add(team);
            }
        }
    }
}
