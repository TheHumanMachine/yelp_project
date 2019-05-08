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
using UIPractive.UserReview;

namespace UIPractive.User_View
{
    /// <summary>
    /// Interaction logic for FriendReviewDisplay.xaml
    /// </summary>
    public partial class FriendReviewDisplay : UserControl
    {
        private String userID;
        private TransactionManager mgr;
        public FriendReviewDisplay(TransactionManager mgr, String userID)
        {
            InitializeComponent();
            this.mgr = mgr;
            this.userID = userID;
        }

        public void AddReview(Review rev, string userName)
        {
            var temp = new ReviewDisplayBox();
            temp.ReviewText = rev.Text;
            temp.FunnyReaction = rev.FunnyVotes.ToString();
            temp.CoolReaction = rev.CoolVotes.ToString();
            temp.UsefulReaction = rev.UsefulVotes.ToString();
            temp.ReviewRating = rev.ReviewStars.ToString();
            temp.Date = rev.Date;
            temp.UserName = userName;

            displayStackPanel.Children.Add(temp);
        }

    }
}
