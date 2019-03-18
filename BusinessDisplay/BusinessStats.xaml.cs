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
    /// Interaction logic for BusinessStats.xaml
    /// </summary>
    public partial class BusinessStats : UserControl
    {
        public BusinessStats()
        {
            InitializeComponent();
        }

        public string Hours
        {
            get { return hoursTextBox.Text; }
            set
            {
                if (value != hoursTextBox.Text)
                {
                    hoursTextBox.Text = value;
                }
            }
        }

        public string Distance
        {
            get { return distanceTextBox.Text; }
            set
            {
                if (value != distanceTextBox.Text)
                {
                    distanceTextBox.Text = value;
                }
            }
        }

        public string Star
        {
            get { return starTextBox.Text; }
            set
            {
                if (value != starTextBox.Text)
                {
                    starTextBox.Text = value;
                }
            }
        }

        public string Reviews
        {
            get { return reviewTextBox.Text; }
            set
            {
                if (value != reviewTextBox.Text)
                {
                    reviewTextBox.Text = value;
                }
            }
        }

        public string ReviewRating
        {
            get { return reviewRatingTextBox.Text; }
            set
            {
                if (value != reviewRatingTextBox.Text)
                {
                    reviewRatingTextBox.Text = value;
                }
            }
        }

        public string CheckIns
        {
            get { return checkinTextBox.Text; }
            set
            {
                if (value != checkinTextBox.Text)
                {
                    checkinTextBox.Text = value;
                }
            }
        }

    }
}
