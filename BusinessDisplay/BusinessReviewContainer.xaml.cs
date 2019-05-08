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
    /// Interaction logic for BusinessReviewContainer.xaml
    /// </summary>
    public partial class BusinessReviewContainer : Window
    {
        private String businessID;
        private TransactionManager mgr;
        private Business currBusiness;
        private Review rev;
        private ReviewsWindow reviews;
        private Boolean isFavorited = false;

        public BusinessReviewContainer(String businessID, TransactionManager mgr)
        {
            InitializeComponent();
            reviews = new ReviewsWindow(businessID, mgr);
            this.businessID = businessID;
            this.mgr = mgr;
            this.rev = new Review();
            reviewDisplay.SetHeader("Review From Friends");
            PopulateReviews();
            getCurrentBusiness();
            isFavorited = mgr.IsFavorited(businessID);
            if (isFavorited) { favoriteButton.Content = "Favorited"; }
        }
        
        private void getCurrentBusiness()
        {
            currBusiness = mgr.ExecuteBusinessQuery(businessID);
            nameField.Text = currBusiness.Name;
            addressField.Text = currBusiness.Address;
            
            foreach(var i in currBusiness.Categories)
            {
                ListBoxItem temp = new ListBoxItem();
                temp.Content = i;
                CategoriesListBox.Items.Add(temp);
            }

            foreach (var i in currBusiness.Attributes)
            {
                ListBoxItem temp = new ListBoxItem();
                temp.Content = i;
                AttributesListBox.Items.Add(temp);
            }
            openField.Text = currBusiness.OpenTime;
            closeField.Text = currBusiness.CloseTime;
        }

        private void PopulateReviews()
        {
            var reviewList = mgr.ExecuteBusinessFriendReviewQuery(businessID);
            foreach(var i in reviewList)
            {
                var name = mgr.ExecuteNameQuery(i.UserID);
                reviewDisplay.AddReview(i, name);
            }
        }

        private void Favorite_Click(object sender, RoutedEventArgs e)
        {
            if (!isFavorited)
            {
                mgr.ExecuteInsertFavoriteBusiness(businessID);
                favoriteButton.Content = "Favorited";
                isFavorited = true;
            }
        }

        private void CheckIn_Click(object sender, RoutedEventArgs e)
        {
            mgr.ExecuteUpdateCheckIn(businessID);
            checkInButton.Content = "Checked in";
        }

        private void ShowCheckIns_Click(object sender, RoutedEventArgs e)
        {
            CheckInGraph checkIn = new CheckInGraph(mgr, businessID);
            checkIn.ShowDialog();
            
        }

        private void ShowReviews_Click(object sender, RoutedEventArgs e)
        {
            reviews.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //    this.rev = new Review();
            //    this.rev.Text = reviewText.Text;
            //    this.rev.FunnyVotes = 0;
            //    this.rev.UsefulVotes = 0;
            //    this.rev.CoolVotes = 0;
            //    DateTime today = DateTime.Today;
            //    this.rev.Date = today.ToShortDateString();
            //    this.rev.BusinessID = businessID;
            //    this.rev.ReviewID = (mgr.GetHighestReviewID() + 1).ToString();
            //    this.rev.ReviewStars = 0;

            //    if ((bool)radioZero.IsChecked)
            //    {
            //        this.rev.ReviewStars = 0;
            //    }
            //    else if ((bool)radioOne.IsChecked)
            //    {
            //        this.rev.ReviewStars = 1;
            //    }
            //    else if ((bool)radioTwo.IsChecked)
            //    {
            //        this.rev.ReviewStars = 2;
            //    }
            //    else if ((bool)radioThree.IsChecked)
            //    {
            //        this.rev.ReviewStars = 3;
            //    }
            //    else if ((bool)radioFour.IsChecked)
            //    {
            //        this.rev.ReviewStars = 4;
            //    }
            //    else if ((bool)radioFive.IsChecked)
            //    {
            //        this.rev.ReviewStars = 5;
            //    }
            //    else
            //    {
            //        this.rev.ReviewStars = 0;
            //    }

            //    mgr.ExecuteInsertReview(rev);
            //    this.Close();
        }
    }
}
