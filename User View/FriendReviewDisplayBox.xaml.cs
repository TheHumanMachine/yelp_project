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

namespace UIPractive.User_View
{
    /// <summary>
    /// Interaction logic for FriendReviewDisplayBox.xaml
    /// </summary>
    public partial class FriendReviewDisplayBox : UserControl
    {

        public FriendReviewDisplayBox()
        {
            InitializeComponent();


        }

        public void SetReviewText(string rev)
        {
            reviewTextBlock.Text = rev;
        }

        public void SetBusinessName(string bus)
        {
            businessTextBox.Text = bus;
        }

        public void SetUsername(string user)
        {
            userNameTextBox.Text = user;
        }

        public void SetJoined(string date)
        {
            postDateTextBox.Text = date;
        }

        //public void SetStarRating(string num)
        //{
        //    reviewStarRatingLabel.Content = num + "/5";
        //}

        //public void SetFunnyRating(int fun)
        //{
        //    funnyTextBox.Text = fun.ToString();
        //}

        //public void SetCoolRating(int cool)
        //{
        //    coolTextBox.Text = cool.ToString();
        //}

        //public void SetUsefulRating(int useful)
        //{
        //    usefulTextBox.Text = useful.ToString();
        //}

    }
}
