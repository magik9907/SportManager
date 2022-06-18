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
    /// Logika interakcji dla klasy TeamDetails.xaml
    /// </summary>
    public partial class TeamDetails : Window
    {
        public Team team { get; set; }
        public TeamDetails(Team team)
        {
            InitializeComponent();
            this.team = team;
            DataContext = team;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void AddPlayer_Click(object sender, RoutedEventArgs e)
        {
            Player player = new Player();
            if(true == player.ShowDialog())
            {
                team.players.Add(player.model);
            }
        }

        private void Deleteplayer_Click(object sender, RoutedEventArgs e)
        {
            Button btn =(Button) sender;
            var parent = (Grid)btn.Parent;
            Models.Player t = (Models.Player)((Border)parent.Parent).DataContext;
            team.players.Remove(t);
        }
    }
}
