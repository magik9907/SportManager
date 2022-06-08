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
    /// Logika interakcji dla klasy MatchDetails.xaml
    /// </summary>
    public partial class MatchDetails : Window
    {
        public Match match { get; set; } 
        public MatchDetails()
        {
            InitializeComponent();
        }

        private void Gol_1(object sender, RoutedEventArgs e)
        {
        }
        private void YellowCard_1(object sender, RoutedEventArgs e)
        {
        }
        private void RedCard_1(object sender, RoutedEventArgs e)
        {
        }
        private void Gol_2(object sender, RoutedEventArgs e)
        {
        }
        private void YellowCard_2(object sender, RoutedEventArgs e)
        {
        }
        private void RedCard_2(object sender, RoutedEventArgs e)
        {
        }



        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
