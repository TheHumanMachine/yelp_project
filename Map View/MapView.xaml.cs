using Microsoft.Maps.MapControl.WPF;
using Npgsql;
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
using UIPractive.DB_Classes;

namespace UIPractive.Map_View
{
    /// <summary>
    /// Interaction logic for mapView.xaml
    /// </summary>
    public partial class MapView : UserControl
    {
        private NpgsqlConnection connection;
        private TransactionManager mgr;

        public MapView(NpgsqlConnection conn, TransactionManager mgr)
        {
            InitializeComponent();
            connection = conn;
            this.mgr = mgr;
        }

        private Boolean ValidLatitudeValue(double lat)
        {
            if (lat >= -90 && lat <= 90)
            {
                return true;
            }
            return false;
        }

        private Boolean ValidLongitudeValue(double longi)
        {
            if (longi >= -180 && longi <= 180)
            {
                return true;
            }
            return false;
        }

        private void place_Pin(String business_Name, double lat, double lon) // Function that focuses on placing pins
        {
            Location location = new Location(lat, lon); // business object's lat and lon are supposed to be here
            Pushpin pushpin = new Pushpin();
            pushpin.Location = location;
            //pushpin.Name = business_Name;
            pushpin.Background = new SolidColorBrush(Colors.Crimson);

            bing_map.Children.Add(pushpin);
        }

        public void plotBusiness(List<Business> busList)
        {
            // Make a function that grabs a business from a list of businesses and put that business' longitude and latitude
            // through the verification function and place a pin in the verified location.
            // make a loop to loop through each business and place a pin there 
            clear_pins();
            foreach (var business in busList)
            {
                // determine if the business' latitude and longitude is valid
                if (ValidLatitudeValue(business.Latitude) && ValidLongitudeValue(business.Longitude))
                {
                    place_Pin(business.Name, business.Latitude, business.Longitude);
                }
                bing_map.Center = new Location(busList.ElementAt(0).Latitude, busList.ElementAt(0).Longitude);

            }

        }

        private void clear_pins()
        {
            bing_map.Children.Clear();
        }
    }
}
