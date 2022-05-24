using SportManager.Models;
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

namespace SportManager
{
    /// <summary>
    /// Logika interakcji dla klasy CreateTournamentxaml.xaml
    /// </summary>
    public partial class CreateTournament : Window
    {
        private Tournament tournament = new Tournament();
        public Tournament Tournament { get { return tournament; } }

        public CreateTournament()
        {
            InitializeComponent();
            FormGrid.DataContext = Tournament;


        }

        private void CreateClick(object sender, RoutedEventArgs e)
        {


            switch (tournament.type)
            {
                case "League":
                    tournament.league = new LeagueStanding();
                    break;

                case "Cup":
                    tournament.cup = new CupStanding();
                    break;

            }
            DialogResult = true;
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void ChangeTournamentType(object sender, RoutedEventArgs e)
        {
            // ... Get RadioButton reference.
            var button = sender as RadioButton;

            // ... Display button content as title.
            this.tournament.type = button.Content.ToString();
        }
    }
}
