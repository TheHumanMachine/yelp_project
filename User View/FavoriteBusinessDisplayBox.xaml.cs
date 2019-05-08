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

namespace UIPractive.User_View
{
    /// <summary>
    /// Interaction logic for FavoriteBusinessDisplayBox.xaml
    /// </summary>
    public partial class FavoriteBusinessDisplayBox : UserControl
    {
        private String business_id;
        public FavoriteBusinessDisplayBox(Business bus)
        {
            InitializeComponent();
            business_id = bus.BusinessID;
            addressTextBox.Text = bus.Address;
            cityTextBox.Text = bus.City;
            stateTextBox.Text = bus.State;
            zipcodeTextBox.Text = bus.Zipcode;
            nameTextBox.Text = bus.Name;
            reviewStarRatingLabel.Content = bus.ReviewRating.ToString();
        }
        
        public string Business_id { get => business_id; set => business_id = value; }
    }
}
