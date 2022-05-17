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
using static SportManager.Models.CupStanding;

namespace SportManager
{
    /// <summary>
    /// Logika interakcji dla klasy TournamentDetails.xaml
    /// </summary>
    public partial class TournamentDetails : Window
    {
        public Tournament tournament;
        private Collection<Team> teams = new Collection<Team>();

        public TournamentDetails(Tournament tournament, Collection<Team> teams)
        {
            InitializeComponent();
            this.tournament = tournament;
            this.title.Text = tournament.title;

            leagueStandingView.ItemsSource = tournament.league.rank;
            buildCupView();

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
                    roundTitle.Text = "Rounds 1/" + Math.Pow(2, i);
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
                    Match match = null;
                    if (y < matches.Count)
                        match = matches[y];
                    TextBlock matchDesc = new TextBlock();
                    if (match == null)
                        matchDesc.Text = "No match";
                    else
                    {
                        matchDesc.Text = String.Concat((match.host != null)
                            ? (match.host.name
                            + " ["
                            + match.host_goal)
                            : ("No team [-"), ":", (
                            (match.guest != null)
                            ? (match.guest_goal
                            + "] "
                            + match.guest.name)
                            : "-] No Team")
                        );
                    }
                    matchDesc.HorizontalAlignment = HorizontalAlignment.Center;
                    Border border = new Border();
                    border.Child = matchDesc;
                    border.BorderThickness = new Thickness(3);
                    border.BorderBrush = Brushes.Black;
                    border.Padding = new Thickness(20, 10, 20, 10);
                    border.Padding = new Thickness(20, 10, 20, 10);

                    LinearGradientBrush winnerBG = new LinearGradientBrush();
                    winnerBG.StartPoint = new Point(0, 0);
                    winnerBG.EndPoint = new Point(1, 1);
                    if ((match == null || match.guest == null || match.host == null)) {
                        GradientStop defaultBG = new GradientStop();
                        defaultBG.Color = Colors.LightSteelBlue;
                        defaultBG.Offset = 0.0;
                        winnerBG.GradientStops.Add(defaultBG);
                    }
                    else 
                    if ( match.guest_goal > match.host_goal)
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
                    border.Background = winnerBG;
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

        }

        public void clickRemoveTeam(object sender, RoutedEventArgs e)
        {

        }
    }
}
