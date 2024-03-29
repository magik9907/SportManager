﻿using System;
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
using static SportManager.Models.CupStanding;

namespace SportManager
{
    /// <summary>
    /// Logika interakcji dla klasy TournamentDetails.xaml
    /// </summary>
    public partial class TournamentDetails : Window
    {
        public Tournament tournament;
        private Collection<Team> allTeams;
        private ObservableCollection<Team> teams = new ObservableCollection<Team>();
        private ObservableCollection<Team> participantsTeams = new ObservableCollection<Team>();
        public TournamentDetails(Tournament tournament, Collection<Team> teams)
        {
            InitializeComponent();
            if (tournament == null) return;
            this.tournament = tournament;
            this.title.Text = tournament.title;
            this.allTeams = teams;

            foreach (Team team in teams)
            {
                if (tournament.teams != null && !tournament.teams.Contains(team))
                {
                    this.teams.Add(team);
                }
            }

            foreach (Team team in tournament.teams)
            {
                this.participantsTeams.Add(team);
            }

            allTeamsListBox.ItemsSource = this.teams;
            participatingTeamsListBox.ItemsSource = participantsTeams;

            stateInitWindow();
        }

        public void stateInitWindow()
        {
            switch (tournament.status)
            {
                case Models.enums.TournamentStatus.NOT_STARTED:
                    matches.Visibility = Visibility.Hidden;
                    standing.Visibility = Visibility.Hidden;
                    cup.Visibility = Visibility.Hidden;
                    statistic.Visibility = Visibility.Hidden;
                    participants.Visibility = Visibility.Visible;
                    add.Visibility = Visibility.Visible;
                    startTournament.Visibility = Visibility.Visible;
                    endTournament.Visibility = Visibility.Hidden;
                    participants.IsSelected = true;
                    break;
                case Models.enums.TournamentStatus.IN_PRROGRESS:
                    if (tournament.type == "Cup")
                    {
                        statistic.Visibility = Visibility.Hidden;
                        cup.IsSelected = true;
                        buildCupView();
                        cup.Visibility = Visibility.Visible;
                        matches.Visibility = Visibility.Hidden;
                        standing.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        statistic.Visibility = Visibility.Visible;
                        standing.IsSelected = true;
                        cup.Visibility = Visibility.Hidden;
                        leagueStandingView.ItemsSource = tournament.league.rank;
                        matches.Visibility = Visibility.Visible;
                        standing.Visibility = Visibility.Visible;
                    }
                    participants.Visibility = Visibility.Visible;
                    add.Visibility = Visibility.Hidden;
                    endTournament.Visibility = Visibility.Visible;
                    startTournament.Visibility = Visibility.Hidden;
                    removeTeamBtn.Visibility = Visibility.Hidden;
                    break;
                case Models.enums.TournamentStatus.DONE:
                    if (tournament.type == "League")
                    {
                        standing.IsSelected = true;
                        matches.Visibility = Visibility.Visible;
                        standing.Visibility = Visibility.Visible;
                        cup.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        buildCupView();
                        cup.IsSelected = true;
                        matches.Visibility = Visibility.Hidden;
                        standing.Visibility = Visibility.Hidden;
                        cup.Visibility = Visibility.Visible;
                    }
                    statistic.Visibility = Visibility.Visible;
                    participants.Visibility = Visibility.Visible;
                    add.Visibility = Visibility.Hidden;
                    startTournament.Visibility = Visibility.Hidden;
                    endTournament.Visibility = Visibility.Hidden;
                    removeTeamBtn.Visibility = Visibility.Hidden;
                    break;
            }
        }

        public void buildCupView()
        {
            List<CupRound> cupRounds = tournament.cup.cupRound;
            int rounds = cupRounds.Count();
            int numberOfMatchesInFirstRound = ((int)Math.Pow(2, rounds - 1));
            Grid grid = new Grid();
            RowDefinition row;
            ColumnDefinition column;
            for (int i = 0; numberOfMatchesInFirstRound + 1 > i; i++)
            {
                column = new ColumnDefinition();
                column.Width = new GridLength(1, GridUnitType.Star);
                grid.ColumnDefinitions.Add(column);
                if (i < rounds)
                {
                    row = new RowDefinition();
                    row.Height = new GridLength(1, GridUnitType.Auto);
                    grid.RowDefinitions.Add(row);
                    TextBlock roundTitle = new TextBlock();
                    roundTitle.Text = "Runda 1/" + Math.Pow(2, i);
                    roundTitle.FontSize = 12;
                    roundTitle.VerticalAlignment = VerticalAlignment.Center;
                    roundTitle.HorizontalAlignment = HorizontalAlignment.Center;
                    roundTitle.FontWeight = FontWeights.Bold;

                    Border border = new Border();
                    border.Child = roundTitle;
                    border.Background = Brushes.LightGray;
                    border.BorderThickness = new Thickness(1);
                    border.BorderBrush = Brushes.Black;
                    border.Padding = new Thickness(20, 10, 20, 10);
                    border.Padding = new Thickness(20, 10, 20, 10);
                    Grid.SetRow(border, rounds - i - 1);
                    Grid.SetColumn(border, 0);
                    grid.Children.Add(border);
                }
            }
            int actualColumnNumberToSpan = 1;
            for (int i = rounds - 1; i >= 0; i--)
            {
                List<Match> matches = cupRounds[i].matches;

                for (int y = 0; y < Math.Pow(2, i); y++)
                {

                    int r = i;
                    int m = y;
                    Match match = null;
                    if (y < matches.Count)
                        match = matches[y];
                    TextBlock matchDesc = new TextBlock();
                    setCupMatchContent(match, matchDesc);
                    if (match != null && match.host != null && match.guest != null)
                        matchDesc.HorizontalAlignment = HorizontalAlignment.Center;

                    MatchButton btn = new MatchButton();
                    btn.match = match;
                    btn.Content = matchDesc;
                    btn.BorderThickness = new Thickness(0);
                    btn.Background = Brushes.Transparent;
                    btn.AddHandler(Button.ClickEvent, new RoutedEventHandler((object sender, RoutedEventArgs e) =>
                    {
                        showCupMatch(sender, e, r, m, grid);
                    }));

                    Border border = new Border();
                    border.Child = btn;
                    border.BorderThickness = new Thickness(3);
                    border.BorderBrush = Brushes.Black;
                    border.Padding = new Thickness(20, 10, 20, 10);
                    border.Padding = new Thickness(20, 10, 20, 10);


                    border.Background = defineMatchGradient(match, matchDesc);
                    Grid.SetRow(border, rounds - i - 1);
                    Grid.SetColumn(border, actualColumnNumberToSpan * y + 1);
                    Grid.SetColumnSpan(border, actualColumnNumberToSpan);
                    grid.Children.Add(border);
                }
                actualColumnNumberToSpan *= 2;
            }



            CupView.Content = grid;
        }

        public void clickAddTeam(object sender, RoutedEventArgs e)
        {
            if (allTeamsListBox.SelectedItem != null)
            {
                tournament.teams.Add(teams.ElementAt(allTeamsListBox.SelectedIndex));
                this.allTeams.Remove(teams.ElementAt(allTeamsListBox.SelectedIndex));
                filter(participantsTeams, tournament.teams, findParticipantBox.Text);
                filter(teams, allTeams, findNewTeamBox.Text);
                participatingTeamsListBox.Items.Refresh();
                allTeamsListBox.Items.Refresh();
                if (allTeamsListBox.Items.Count <= 0)
                {
                    buttonAllTeamListAdd.IsEnabled = false;

                }
                else
                {
                    buttonAllTeamListAdd.IsEnabled = true;
                    removeTeamBtn.IsEnabled = true;
                }
            }
        }

        public void clickRemoveTeam(object sender, RoutedEventArgs e)
        {
            if (participatingTeamsListBox.SelectedItem != null)
            {
                allTeams.Add(participantsTeams.ElementAt(participatingTeamsListBox.SelectedIndex));
                tournament.teams.Remove(tournament.teams.ElementAt(participatingTeamsListBox.SelectedIndex));
                filter(participantsTeams, tournament.teams, findParticipantBox.Text);
                filter(teams, allTeams, findNewTeamBox.Text);
                participatingTeamsListBox.Items.Refresh();
                allTeamsListBox.Items.Refresh();
                if (participatingTeamsListBox.Items.Count <= 0)
                {
                    removeTeamBtn.IsEnabled = false;
                }
                else
                {
                    removeTeamBtn.IsEnabled = true;
                    buttonAllTeamListAdd.IsEnabled = true;
                }
            }
        }

        private void filter(ObservableCollection<Team> t, Collection<Team> c, String title)
        {
            t.Clear();

            foreach (var x in c)
            {
                if (title == x.name || x.name.Contains(title))
                {
                    t.Add(x);
                }
            }
        }

        private void startTournament_Click(object sender, RoutedEventArgs e)
        {
            if (tournament.teams.Count() > tournament.numberOfTeams)
            {
                MessageBox.Show("Liczba zespołów jest za duża", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (tournament.teams.Count() < 2)
            {
                MessageBox.Show("Minimalna liczba zespołów to 2 ", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            tournament.startTournament(matchesListBox);
            stateInitWindow();
        }

        private void endTournament_Click(object sender, RoutedEventArgs e)
        {
            tournament.status = Models.enums.TournamentStatus.DONE;
            stateInitWindow();
        }

        private void showCupMatch(object sender, RoutedEventArgs e, int round, int matchNumber, Grid grid)
        {
            MatchButton matchBtn = (MatchButton)sender;
            Match m = (matchBtn).match;
            if (m == null) return;
            MatchDetails matchDetails = new MatchDetails(m, teams);
            matchDetails.match = m;
            if (true == matchDetails.ShowDialog()
                && m != null
                && tournament.status == Models.enums.TournamentStatus.IN_PRROGRESS)
            {
                Border parent = (Border)matchBtn.Parent;
                TextBlock matchDesc = (TextBlock)matchBtn.Content;
                if (round > 0)
                {
                    bool isAsHost = matchNumber % 2 == 0;
                    int matchNumberInNextRound = (int)Math.Floor((double)matchNumber / 2);
                    int matchIndex = 0;
                    for (int i = tournament.cup.cupRound.Count - 1; i >= round - 1; i--)
                    {
                        matchIndex += 1;
                        if (i == 0) matchIndex += 1;
                        else
                            matchIndex += ((int)Math.Pow(2, i));
                    }
                    matchIndex += (matchNumberInNextRound - 1);
                    Match newMatch = tournament.cup.cupRound[round - 1].matches[matchNumberInNextRound];
                    Border nextMatch = (Border)grid.Children[matchIndex];
                    if (isAsHost)
                        newMatch.host = !m.winner ? m.guest : m.host;
                    else
                        newMatch.guest = !m.winner ? m.guest : m.host;

                    parent.Background = defineMatchGradient(newMatch, matchDesc);
                    nextMatch.Background = defineMatchGradient(newMatch, matchDesc);
                    setCupMatchContent(newMatch, ((TextBlock)(((Button)(((Border)nextMatch).Child)).Content)));
                }
                parent.Background = defineMatchGradient(m, matchDesc);
                setCupMatchContent(m, ((TextBlock)(matchBtn.Content)));

            }
        }

        private LinearGradientBrush defineMatchGradient(Match match, TextBlock matchDesc)
        {
            LinearGradientBrush winnerBG = new LinearGradientBrush();
            winnerBG.StartPoint = new Point(0, 0);
            winnerBG.EndPoint = new Point(1, 1);
            if (match == null || match.guest == null || match.host == null)
            {
                GradientStop defaultBG = new GradientStop();
                defaultBG.Color = Colors.LightSteelBlue;
                defaultBG.Offset = 0.0;
                winnerBG.GradientStops.Add(defaultBG);
            }
            else
            if (match.guest_goal > match.host_goal)
            {
                GradientStop red = new GradientStop();
                red.Color = Colors.Red;
                red.Offset = 0.0;
                winnerBG.GradientStops.Add(red);
                GradientStop green = new GradientStop();
                green.Color = Colors.Green;
                green.Offset = 1;
                winnerBG.GradientStops.Add(green);
                matchDesc.Foreground = Brushes.White;
            }
            else
            if (match.guest_goal < match.host_goal)
            {

                GradientStop red = new GradientStop();
                red.Color = Colors.Red;
                red.Offset = 1.0;
                winnerBG.GradientStops.Add(red);
                GradientStop green = new GradientStop();
                green.Color = Colors.Green;
                green.Offset = 0;
                winnerBG.GradientStops.Add(green);
                matchDesc.Foreground = Brushes.White;
            }
            else
            {
                GradientStop defaultBG = new GradientStop();
                defaultBG.Color = Colors.LightBlue;
                defaultBG.Offset = 0.0;
                winnerBG.GradientStops.Add(defaultBG);
            }
            return winnerBG;
        }

        private void setCupMatchContent(Match match, TextBlock matchDesc)
        {
            if (match == null)
                matchDesc.Text = "Brak meczu";
            else
            {
                matchDesc.Text = String.Concat((match.host != null)
                    ? (match.host.name
                    + " ["
                    + match.host_goal)
                    : ("Brak drużyny [-"), ":", (
                    (match.guest != null)
                    ? (match.guest_goal
                    + "] "
                    + match.guest.name)
                    : "-] Brak drużyny")
                );
            }
        }

        public class MatchButton : Button
        {
            public Match match { get; set; }
        }

        private void showMatch(object sender, SelectionChangedEventArgs e)
        {
            var btn = sender as ListBox;
            Match match = (Match)btn.SelectedItem;
            MatchDetails matchDetails = new MatchDetails(match, teams);
            System.Diagnostics.Debug.WriteLine(match.matchEnded);
            if (true == matchDetails.ShowDialog())
            {
                standigsUpdate(match);
                matchesListBox.Items.Refresh();

            }
        }

        private void findParticipantBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            filter(participantsTeams, tournament.teams, findParticipantBox.Text);

        }

        private void findNewTeamBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            filter(teams, allTeams, findNewTeamBox.Text);
        }

        private void teamDetails_Click(object sender, RoutedEventArgs e)
        {
            var team = ((Team)((Grid)((Button)sender).Parent).DataContext);
            TeamDetails teamDetail = new TeamDetails(team);
            teamDetail.ShowDialog();
        }
        public void standigsUpdate(Match match)
        {
            LeagueStanding league = tournament.league;

            if (match.matchEnded)
            {
                foreach (var teamstats in league.rank)
                {
                    if (teamstats.team == match.host)
                    {
                        if (match.host_goal > match.guest_goal)
                        {
                            teamstats.win++;
                            teamstats.goal_for += match.host_goal;
                            teamstats.goal_against += match.guest_goal;
                            teamstats.points += 3;
                        }
                        else if (match.host_goal < match.guest_goal)
                        {
                            teamstats.loose++;
                            teamstats.goal_for += match.host_goal;
                            teamstats.goal_against += match.guest_goal;

                        }
                        else
                        {
                            teamstats.draw++;
                            teamstats.goal_for += match.host_goal;
                            teamstats.goal_against += match.guest_goal;
                            teamstats.points++;
                        }
                    }
                    else if (teamstats.team == match.guest)
                    {
                        if (match.host_goal > match.guest_goal)
                        {

                            teamstats.loose++;
                            teamstats.goal_for += match.guest_goal;
                            teamstats.goal_against += match.host_goal;
                        }
                        else if (match.host_goal < match.guest_goal)
                        {
                            teamstats.win++;
                            teamstats.goal_for += match.guest_goal;
                            teamstats.goal_against += match.host_goal;
                            teamstats.points += 3;

                        }
                        else
                        {
                            teamstats.draw++;
                            teamstats.goal_for += match.guest_goal;
                            teamstats.goal_against += match.host_goal;
                            teamstats.points++;
                        }
                    }
                }
            }
            //sortowanie po punktach i przypisywanie lp
            bool[] check = new bool[league.rank.Count];
            for (int i = 1; i < league.rank.Count + 1; i++)
            {
                int max = -3;
                int temp = -3;
                for (int j = 0; j < league.rank.Count; j++)
                {
                    if (!check[j])
                    {
                        if (league.rank[j].points > max)
                        {

                            max = league.rank[j].points;
                            temp = j;

                        }
                    }

                }
                if (temp != -3)
                {
                    league.rank[temp].lp = i;
                    check[temp] = true;
                }
            }
            league.rank.Sort((x, y) => x.lp.CompareTo(y.lp));
            leagueStandingView.Items.Refresh();
        }

        private void openDescription_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(tournament.description, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
