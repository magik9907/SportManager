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

namespace SportManager
{
    public partial class MainWindow : Window
    {
        private List<Tournament> tournaments = new List<Tournament>();

        public MainWindow()
        {
            InitializeComponent();
            tournametsList.ItemsSource = tournaments;

            tournaments.AddRange(new[] {
                new Tournament(1, "Tournament 1", DateTime.Parse("2022-01-11"), TournamentStatus.NOT_STARTED),
        new Tournament(2, "Tournament 2", DateTime.Parse("2022-11-22"), TournamentStatus.IN_PRROGRESS),
        new Tournament(3, "Tournament 3", DateTime.Parse("2022-03-11"), TournamentStatus.NOT_STARTED),
        new Tournament(4, "Tournament 4", DateTime.Parse("2022-06-22"), TournamentStatus.DONE),
        new Tournament(5, "Tournament 5", DateTime.Parse("2022-05-11"), TournamentStatus.NOT_STARTED)
       });
        }

        private void Create_Tournament(object sender, RoutedEventArgs e)
        {
            CreateTournament create = new CreateTournament();
            if(true == create.ShowDialog())
            {

            }
        }
    }
}
