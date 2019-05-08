
using System.Windows.Controls;
using UIPractive.DB_Classes;

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

        public void SetHeader(string nName)
        {
            groupBox.Header = nName;
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
            temp.BusinessName = rev.BusinessName;
            reviewStackPanel.Children.Add(temp);
        }
    }
}
