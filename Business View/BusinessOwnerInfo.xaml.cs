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

namespace UIPractive.Business_View
{
    /// <summary>
    /// Interaction logic for BusinessOwnerInfo.xaml
    /// </summary>
    public partial class BusinessOwnerInfo : UserControl
    {
        public BusinessOwnerInfo()
        {
            InitializeComponent();
        }

        public void AddBusinessToDisplay(Business bus)
        {
            reviewRatingTextBox.Text = bus.ReviewRating.ToString();
            reviewTextBox.Text = bus.ReviewCount.ToString();
            starTextBox.Text = bus.Stars.ToString();
            checkinTextBox.Text = bus.CheckInCount.ToString();
        }


    }
}
