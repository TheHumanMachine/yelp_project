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

namespace UIPractive.UserReview
{
    /// <summary>
    /// Interaction logic for ReviewDisplay.xaml
    /// </summary>
    public partial class ReviewDisplay : UserControl
    {
        public ReviewDisplay()
        {
            InitializeComponent();
        }

        public void AddReview(ReviewDisplayBox review)
        {
            reviewStackPanel.Children.Add(review);
        }
    }
}
