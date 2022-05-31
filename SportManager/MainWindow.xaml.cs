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
        public Collection<Team> teams = new Collection<Team>();
        public ViewModel tournaments = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
            tournametsList.ItemsSource = tournaments.tournaments;

            //TODO delete mock

            teams.Add(
                new Team(1, "FC Barcelona", "C. d'Arístides Maillol", "12", "08028", "Barcelona"));
            teams.Add(
                new Team(2, "Bayern Monachium", "Werner-Heisenberg-Allee", "25", "80939 ", "München"));


        }

        private void Create_Tournament(object sender, RoutedEventArgs e)
        {
            CreateTournament create = new CreateTournament();
            if (true == create.ShowDialog())
            {
                var btn = sender as Button;

              tournaments.tournaments.Add(create.Tournament);
            }
        }


        private void showTournament(object sender, SelectionChangedEventArgs e)
        {
            var btn = sender as ListBox;
            Tournament tournament = (Tournament)btn.SelectedItem;
            TournamentDetails tournamentDetails = new TournamentDetails(tournament, teams);
            if (true == tournamentDetails.ShowDialog())
            {

            }
        }
        private void createTeam(object sender, RoutedEventArgs e)
        {
            CreateTeam createTeam = new CreateTeam();
            createTeam.Title = "Create a new team";
            createTeam.Owner = this;
            if (true == createTeam.ShowDialog())
            {
                Console.WriteLine("\n tworenie nowego zsespolu");
                Team team = new Team(teams.Count() + 1, createTeam.nameBox.Text, createTeam.streetNameBox.Text, createTeam.streetNumberBox.Text, createTeam.postalCodeBox.Text, createTeam.cityBox.Text, createTeam.imgPhoto.Source);
                teams.Add(team);
            }

        }

        public class ViewModel
        {
            public ObservableCollection<Tournament> tournaments { get; private set; }
            public ViewModel()
            {
                this.tournaments = new ObservableCollection<Tournament>();

                //TODO delete mock
                CupStanding cup = new CupStanding();
                cup.mock();

                LeagueStanding league = new LeagueStanding();

                league.mock();
                tournaments.Add(
                    new Tournament(1, "Tournament 1", DateTime.Parse("2022-01-11"), 4, TournamentStatus.NOT_STARTED, league, cup,"Cup"));
                tournaments.Add(new Tournament(2, "Tournament 2", DateTime.Parse("2022-11-22"), 4,TournamentStatus.IN_PRROGRESS, league, cup, "League"));
                tournaments.Add(new Tournament(3, "Tournament 3", DateTime.Parse("2022-03-11"), 4, TournamentStatus.NOT_STARTED, league, cup, "Cup"));
                tournaments.Add(new Tournament(4, "Tournament 4", DateTime.Parse("2022-06-22"), 4, TournamentStatus.DONE, league, cup, "Cup"));
                tournaments.Add(new Tournament(5, "Tournament 5", DateTime.Parse("2022-05-11"), 4, TournamentStatus.NOT_STARTED, league, cup, "Cup"));

            }
        }
    }
}
