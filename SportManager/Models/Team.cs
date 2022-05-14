using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace SportManager.Models
{
    public class Team
    {
        public int id { get; set; }
        public string name { get; set; }
        
        public string address { get; set; }

        public BitmapImage crest { get; set; }


        public string streetName
        {
            get { return streetName; }
            set 
            {
                foreach(char c in value)
                {
                    if (c < 'A' || c > 'z')
                        throw new ArgumentException("Street name contains only letters!");
                }
                streetName = value; }
        }
        public string streetNumber
        { 
            get{ return streetNumber; }
            set
            {
                foreach (char c in value)
                {
                    if (c < '0' || c > '9')
                        throw new ArgumentException("Street number contains only numbers!");
                }
                streetNumber = value;
            }
        }
        public string city
        {
            get { return city; }
            set
            {
                foreach (char c in value)
                {
                    if (c < 'A' || c > 'z')
                        throw new ArgumentException("City contains only letters!");
                }
                city = value;
            }
        }

        public string postalCode
        {
            get { return postalCode; }
            set
            {
                foreach(char c in value)
                {
                    if ((c < '0' || c > '9') || c != '-')
                        throw new ArgumentException("Postal code contains letter and '-'");
                }
            }
        }

        public Team(int id, string name, string streetName, string streetNumber, string postalCode, string city)
        {
            this.id = id;
            this.name = name;
            this.streetName = streetName;
            this.streetNumber = streetNumber;
            this.postalCode = postalCode;
            this.city = city;
        }
        public Team(int id, string name, string streetName, string streetNumber, string postalCode, string city, BitmapImage crest)
        {
            this.id = id;
            this.name = name;
            this.streetName = streetName;
            this.streetNumber = streetNumber;
            this.postalCode = postalCode;
            this.city = city;
            this.crest = crest;
        }

        public string addressToString
        {
            get { return $"Address: {streetName} {streetNumber}, {postalCode} {city}"; }
        }

        }


}

