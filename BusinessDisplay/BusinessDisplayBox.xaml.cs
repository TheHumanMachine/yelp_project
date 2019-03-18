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

namespace UIPractive
{
    /// <summary>
    /// Interaction logic for BusinessDisplayBox.xaml
    /// </summary>
    public partial class BusinessDisplayBox : UserControl
    {
        private BusinessStats stats;
        private BusinessInformation info;

        public BusinessDisplayBox()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public void AddBusinessDisplayComponents()
        {
            stats = new BusinessStats();
            stats.Distance = "15";
            stats.Reviews = "6";
            stats.Star = "4.8";
            stats.ReviewRating = "4.6";
            stats.CheckIns = "10";
            stats.Hours = "Always";


            info = new BusinessInformation();
            info.Address = "Kris's House";
            info.City = "Everett";
            info.Zipcode = "98204";
            info.State = "WA";
            info.BusinessName = "Burrito Technologies, Inc";

            UpperGrid.Children.Add(info);
            LowerGrid.Children.Add(stats);
        }

        private void UserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("THIS SHEIT WAS DOUBLE CLICKED!!!!");
        }
    }
}
