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

namespace UIPractive.User_View
{
    /// <summary>
    /// Interaction logic for EditUserCoordinate.xaml
    /// </summary>
    public partial class EditUserCoordinate : Window
    {
        TextBox lat;
        TextBox lon;
        TransactionManager mgr;

        public EditUserCoordinate(TextBox lat, TextBox lon, TransactionManager mgr)
        {
            InitializeComponent();
            this.mgr = mgr;
            this.lat = lat;
            this.lon = lon;
        }

        private void submit_click(object sender, RoutedEventArgs e)
        {
            
            double latCoord = Double.Parse(latBox.Text);
            double lonCoord = Double.Parse(lonBox.Text);

            if(latCoord > -90 && latCoord < 90 && lonCoord > -180 && lonCoord < 180)
            {
                lat.Text = latBox.Text;
                lon.Text = lonBox.Text;
                mgr.ExecuteUpdateUserLocation(latCoord, lonCoord);
                this.Close();
            }
            
        }
    }
}
