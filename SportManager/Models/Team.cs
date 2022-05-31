using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace SportManager.Models
{
    public class Team
    {
        public int id { get; set; }
        public string name { get; set; }
        
        public string address { get; set; }

        public ImageSource crest { get; set; } = new BitmapImage(new Uri("pack://application:,,,/images/defaultcrest.png"));


        public string streetName { get; set; }
       
        public string streetNumber { get; set; }

        public string city { get; set; }


        public string postalCode { get; set; }

        public Team() { }
        public Team(int id, string name, string streetName, string streetNumber, string postalCode, string city)
        {
            this.id = id;
            this.name = name;
            this.streetName = streetName;
            this.streetNumber = streetNumber;
            this.postalCode = postalCode;
            this.city = city;
            this.address = streetName + " " + streetNumber + ", " + postalCode + " " + city;
        }
        public Team(int id, string name, string streetName, string streetNumber, string postalCode, string city, ImageSource crest)
        {
            this.id = id;
            this.name = name;
            this.streetName = streetName;
            this.streetNumber = streetNumber;
            this.postalCode = postalCode;
            this.city = city;
            if(crest != null)
            {
                this.crest = crest;
            }
            else
            {
                this.crest = new BitmapImage(new Uri("pack://application:,,,/images/defaultcrest.png"));
            }
            this.address = streetName + " " + streetNumber + ", " + postalCode + " " + city;
        }

        public string addressToString
        {
            get { return $"Address: {streetName} {streetNumber}, {postalCode} {city}"; }
        }

        }


}

