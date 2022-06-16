﻿using SportManager.Models;
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

            teams.Add(
                new Team(3, "Jagielonia", "Stadion miejscki", "25", "80939 ", "Białystok"));


        }

        private void Create_Tournament(object sender, RoutedEventArgs e)
        {
            CreateTournament create = new CreateTournament();
            if (true == create.ShowDialog())
            {
                var btn = sender as Button;

                tournaments.addTournament(create.Tournament, tournamentName.Text, sort.Text, selectState.SelectedIndex == 3 ? null : (TournamentStatus)Enum.Parse(typeof(TournamentStatus), selectState.SelectedIndex.ToString()));
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
            private Collection<Tournament> tournamentsCopy { get; set; }
            public ObservableCollection<Tournament> tournaments { get; private set; }
            public ViewModel()
            {
                this.tournaments = new ObservableCollection<Tournament>();
                tournamentsCopy = new Collection<Tournament>();
                //TODO delete mock
                CupStanding cup = new CupStanding();
                cup.mock();

                LeagueStanding league = new LeagueStanding();

                league.mock();
                tournamentsCopy.Add(
                    new Tournament(1, "Tournament 1", DateTime.Parse("2022-01-11"), 4, TournamentStatus.NOT_STARTED, null, new CupStanding(), "Cup"));
                tournamentsCopy.Add(new Tournament(2, "Tournament 2", DateTime.Parse("2022-11-22"), 4, TournamentStatus.IN_PRROGRESS, league, cup, "League"));
                tournamentsCopy.Add(new Tournament(3, "Tournament 3", DateTime.Parse("2022-03-11"), 4, TournamentStatus.NOT_STARTED, league, cup, "Cup"));
                tournamentsCopy.Add(new Tournament(4, "Tournament 4", DateTime.Parse("2022-06-22"), 4, TournamentStatus.DONE, league, cup, "Cup"));
                tournamentsCopy.Add(new Tournament(5, "Tournament 5", DateTime.Parse("2022-05-11"), 4, TournamentStatus.NOT_STARTED, league, cup, "Cup"));
                filter("", "Start date - descending", null);
            }

            public void filter(String title, string sort, TournamentStatus? status)
            {
                tournaments.Clear();
                List<Tournament> list;
                if (title == "") list = tournamentsCopy.ToList();
                else
                    list = tournamentsCopy.Where(x => (title == "" || x.title.Contains(title))).ToList();
                if (status != null)
                    list = tournamentsCopy.Where(x => x.status == status).ToList();
                sortList(list, sort).ForEach(x => tournaments.Add(x));
            }


            private List<Tournament> sortList(List<Tournament> t, string s)
            {

                switch (s)
                {
                    case "Start date - descending": return t.OrderBy(x => x.startDate).ToList();

                    case "Start date - ascending": return t.OrderByDescending(x => x.startDate).ToList();

                    case "Status - ascending": return t.OrderByDescending(x => x.status).ToList();

                    case "Status - descending": return t.OrderBy(x => x.status).ToList();
                }

                return t;

            }

            public void addTournament(Tournament t, String title, string sort, TournamentStatus? status)
            {
                tournamentsCopy.Add(t);
                filter(title, sort, status);

            }

        }

        private void filter()
        {
            tournaments.filter(tournamentName != null ? tournamentName.Text : "", sort.Text, selectState == null||selectState.SelectedIndex == 3  ? null : (TournamentStatus)Enum.Parse(typeof(TournamentStatus), selectState.SelectedIndex.ToString()));
        }

        private void Sort(object sender, RoutedEventArgs e)
        {
            filter();
        }

        private void SelectState(object sender, RoutedEventArgs e)
        {
            filter();
        }

        private void TournamentTitleChange(object sender, RoutedEventArgs e)
        {
            filter();
        }


    }
}
