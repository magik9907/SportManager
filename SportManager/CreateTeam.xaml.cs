using Microsoft.Win32;
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
    /// Logika interakcji dla klasy CreateTeam.xaml
    /// </summary>
    public partial class CreateTeam : Window
    {
        bool namePassed;
        bool streetNamePassed;
        bool cityPassed;
        bool streetNumberPassed;
        bool postalCodePassed;

        public CreateTeam()
        {
            InitializeComponent();
        }

        public void chooseCrestClick(object sender,RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                imgPhoto.Source = new BitmapImage(new Uri(op.FileName));
            }
            
        }
        private void okClick(object sender, RoutedEventArgs e)
        {
            if(namePassed && streetNamePassed && cityPassed && streetNumberPassed && postalCodePassed)
            {
                MessageBox.Show("Utworzenie drużyny zakończyło się powodzeniem.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Nie wszystkie pola wypełniono poprawnie.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void nameValidation(object sender, RoutedEventArgs e)
        {
            if(nameBox.Text.Length >= 20)
            {
                nameValidationLabel.Content = "Name must be less than 20 characters";
                namePassed = false;
              
            }
            else if(nameBox.Text.Length <= 5)
            {
                nameValidationLabel.Content = "Name must be at least 6 characters long";
                namePassed = false;
            }
            else
            {
                nameValidationLabel.Content = null;
                namePassed = true;
            }
        }
        public void streetNameValidation(object sender, RoutedEventArgs e)
        {
            if (streetNameBox.Text.Length >= 20)
            {
                streetNameValidationLabel.Content = "Street Name must be less than 20 characters";
                streetNamePassed = false;
                return;
            }
            if (streetNameBox.Text.Length <= 2)
            {
                streetNameValidationLabel.Content = "Street Name be at least 3 characters long";
                streetNamePassed = false;
                return;
            }
                
            foreach(char c in streetNameBox.Text)
            {
                    if((c < 'A' || c > 'Z') && (c < 'a' || c > 'z'))
                    {
                        streetNameValidationLabel.Content = "Street name doesn't contain numbers";
                        streetNamePassed = false;
                        return;
                    }
            }
                
            

            streetNameValidationLabel.Content = null;
            streetNamePassed = true;
                return;
            
        }
        public void streetNumberValidation(object sender, RoutedEventArgs e)
        {
            if (streetNumberBox.Text.Length > 3)
            {
                streetNumberValidationLabel.Content = "Street number must be less than 4 characters";
                streetNumberPassed = false;
                return;
            }
            foreach (char c in streetNumberBox.Text)
            {
                if (c < '0' || c > '9')
                {
                    streetNumberValidationLabel.Content = "Street number doesn't contain letters";
                    streetNumberPassed = false;
                    return;
                }
            }
            streetNumberValidationLabel.Content = null;
            streetNumberPassed = true;
        }
        public void postalCodeValidation(object sender, RoutedEventArgs e)
        {
            if (postalCodeBox.Text.Length != 5)
            {
                postalCodeValidationLabel.Content = "Postal code contains 5 numbers";
                postalCodePassed = false;
                return;
            }
            foreach (char c in postalCodeBox.Text)
            {
                if (c < '0' || c > '9')
                {
                    postalCodeValidationLabel.Content = "Street number doesn't contain letters";
                    postalCodePassed = false;
                    return;
                }
            }
            postalCodeValidationLabel.Content = null;
            postalCodePassed = true;
        }
        public void cityValidation(object sender, RoutedEventArgs e)
        {
            if (cityBox.Text.Length >= 20)
            {
                cityValidationLabel.Content = "City name must be less than 20 characters";
                cityPassed = false;
                return;
            }
            if (cityBox.Text.Length <= 2)
            {
                cityValidationLabel.Content = "City name must be at least 3 characters long";
                cityPassed = false;
                return;
            }

            foreach (char c in cityBox.Text)
            {
                if ((c < 'A' || c > 'Z') && (c < 'a' || c > 'z'))
                {
                    cityValidationLabel.Content = "City name doesn't contain numbers";
                    cityPassed = false;
                    return;
                }
            }



            cityValidationLabel.Content = null;
            cityPassed = true;
            return;

        }
    }
}
