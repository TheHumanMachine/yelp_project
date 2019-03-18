using Npgsql;
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
using UIPractive.User_View;
using UIPractive.UserReview;

namespace UIPractive
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string connString = "Host=localhost;Username=postgres;Password=1111111;Database=yelp";
        private NpgsqlConnection connection;
        UserMainView userView;

        public MainWindow()
        {
            InitializeComponent();
            ConnectToDatabase();
            userView = new UserMainView(connection);
            this.AddChild(userView);
        }

        private void ConnectToDatabase()
        {
            connection = new NpgsqlConnection(connString);
            connection.Open();
        }


        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListBox_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }

        private void AddReviewBox()
        {
            ReviewDisplayBox temp = new ReviewDisplayBox();
            temp.UserName = "carlos";
            temp.FunnyReaction = "4";
            temp.CoolReaction = "2";
            temp.UsefulReaction = "0";
            temp.StarRating = "3/5";
            temp.Date = "2019-10-10";
            temp.ReviewText = "This was the most awesome thing ever";
            temp.Height = 200;

            //BusinessDisplayView.Children.Add(temp);
        }

        private void AddBusinessDisplayBox()
        {
            BusinessDisplayBox temp = new BusinessDisplayBox();
            temp.AddBusinessDisplayComponents();
            //BusinessDisplayView.Children.Add(temp);
        }
    }
}
