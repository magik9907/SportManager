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
    /// Logika interakcji dla klasy Player.xaml
    /// </summary>
    public partial class Player : Window
    {
        public Models.Player model = new Models.Player();
        public Player()
        {
            InitializeComponent();
            DataContext = model;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if(model.fullName ==null ||model.fullName == "")
            {
                MessageBox.Show("Imie i nazwisko zawodnika jest wymagane", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (model.position == null || model.position == "")
            {
                MessageBox.Show("Pozycja zawodnika jest wymagana", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void SelectPosition(object sender, RoutedEventArgs e)
        {
            RadioButton rbtn = (RadioButton)sender;
            model.position =(string) rbtn.Content;
        }
    }
}
