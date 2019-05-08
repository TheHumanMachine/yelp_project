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
using UIPractive.BusinessDisplay;
using UIPractive.DB_Classes;

namespace UIPractive
{
    /// <summary>
    /// Interaction logic for BusinessDisplayBox.xaml
    /// </summary>
    public partial class BusinessDisplayBox : UserControl
    {
        private BusinessStats stats;
        private BusinessInformation info;
        private String businessID;
        TransactionManager mgr;

        public BusinessDisplayBox(Business bus, TransactionManager mgr)
        {
            InitializeComponent();
            BusinessDisplayFactory(bus);
            this.mgr = mgr;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BusinessDisplayFactory(Business bus)
        {
            stats = new BusinessStats();
            stats.Distance = bus.Distance.ToString();
            stats.Reviews = bus.ReviewCount.ToString();
            stats.Star = bus.Stars.ToString();
            stats.ReviewRating = bus.ReviewRating.ToString();
            stats.CheckIns = bus.CheckInCount.ToString();
            businessID = bus.BusinessID;

            info = new BusinessInformation();
            info.Address = bus.Address;
            info.City = bus.City;
            info.Zipcode = bus.Zipcode.ToString();
            info.State = bus.State;
            info.BusinessName = bus.Name;

            UpperGrid.Children.Add(info);
            LowerGrid.Children.Add(stats);
        }

        private void UserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BusinessReviewContainer dis = new BusinessReviewContainer(this.businessID, this.mgr);
            dis.ShowDialog();
        }
    }
}
