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
        private Tournament tournament;
        private Collection<Team> teams = new Collection<Team>();

        public TournamentDetails(Tournament tournament, Collection<Team> teams)
        {
            InitializeComponent();
            this.tournament = tournament;
            this.title.Text = tournament.title;
            
        }
    }
}
