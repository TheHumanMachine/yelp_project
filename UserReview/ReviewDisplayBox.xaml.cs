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
    /// Interaction logic for ReviewDisplayBox.xaml
    /// </summary>
    public partial class ReviewDisplayBox : UserControl
    {
        public ReviewDisplayBox()
        {
            InitializeComponent();
        }

        public string UserName
        {
            get { return userNameTextBox.Text; }
            set
            {
                if (value != userNameTextBox.Text)
                {
                    userNameTextBox.Text = value;
                }
            }
        }

        public string Date
        {
            get { return postDateTextBox.Text; }
            set
            {
                if (value != postDateTextBox.Text)
                {
                    postDateTextBox.Text = value;
                }
            }
        }

        public string StarRating
        {
            get { return reviewStarRatingLabel.Content.ToString(); }
            set
            {
                reviewStarRatingLabel.Content = value;
            }
        }

        public string FunnyReaction
        {
            get { return funnyTextBox.Text; }
            set
            {
                if (value != funnyTextBox.Text)
                {
                    funnyTextBox.Text = value;
                }
            }
        }

        public string CoolReaction
        {
            get { return coolTextBox.Text; }
            set
            {
                if (value != coolTextBox.Text)
                {
                    coolTextBox.Text = value;
                }
            }
        }

        public string UsefulReaction
        {
            get { return usefulTextBox.Text; }
            set
            {
                if (value != usefulTextBox.Text)
                {
                    usefulTextBox.Text = value;
                }
            }
        }

        public string ReviewText
        {
            get { return reviewTextBlock.Text; }
            set
            {
                if (value != reviewTextBlock.Text)
                {
                    reviewTextBlock.Text = value;
                }
            }
        }
    }
}
