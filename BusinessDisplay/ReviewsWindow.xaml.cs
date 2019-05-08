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
using UIPractive.DB_Classes;

namespace UIPractive.BusinessDisplay
{
    /// <summary>
    /// Interaction logic for ReviewsWindow.xaml
    /// </summary>
    public partial class ReviewsWindow : Window
    {
        private String business_id;
        private TransactionManager mgr;
        public ReviewsWindow(String business_id, TransactionManager mgr)
        {
            InitializeComponent();
            this.business_id = business_id;
            this.mgr = mgr;
            PopulateReview();
        }

        private void PopulateReview()
        {
            var reviewList = mgr.ExecuteBusinessReviewQuery(business_id);
            foreach (var i in reviewList)
            {
                var name = mgr.ExecuteNameQuery(i.UserID);
                reviewsDisplay.AddReview(i, name);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(reviewTextBox.Text))
            {
                var temp = new Review();
                temp.ReviewID = (mgr.GetHighestReviewID() + 1).ToString();
                temp.Text = reviewTextBox.Text;
                temp.ReviewStars = double.Parse(reviewRatingBox.SelectedIndex.ToString());
                temp.CoolVotes = 0;
                temp.UsefulVotes = 0;
                temp.FunnyVotes = 0;
                DateTime today = DateTime.Today;
                temp.UserID = mgr.CurrentUser;
                temp.BusinessID = business_id;

                mgr.ExecuteInsertReview(temp);
            }
        }
    }
}
