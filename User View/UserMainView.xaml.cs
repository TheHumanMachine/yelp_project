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

namespace UIPractive.User_View
{
    /// <summary>
    /// Interaction logic for UserMainView.xaml
    /// </summary>
    public partial class UserMainView : UserControl
    {
        private NpgsqlConnection connection;
        public string currentUser = "uXjR2GhCAYhqxVr21aC4vQ";
        private TransactionManager mgr;
        private SetUserDisplay SUserDisplay;
        private FriendReviewDisplay friendReviewDisplay;

        public UserMainView(NpgsqlConnection conn, TransactionManager mgr)
        {
            InitializeComponent();
            this.mgr = mgr;
            connection = conn;
            friendReviewDisplay = new FriendReviewDisplay(mgr, currentUser);
            userInfo.AddManager(mgr);
            businessDisplay.AddManager(mgr);
            friendReviews.Children.Add(friendReviewDisplay);
            LoadUserInformation();
            SUserDisplay = new SetUserDisplay(mgr,this);
            SUserDisplay.userIDTextBox.Text = currentUser;
            SUserDisplay.currentUserBtn.Click += NewUserHandler;
            UserDisplayGrid.Children.Add(SUserDisplay);
            LoadFavoriteBusinesses();
            businessDisplay.removeButton.Click += FavoriteBusinessesChanged;
            this.Loaded += FavoriteBusinessesChanged;
        }

        /// <summary>
        /// Updates the new users names, fans, votes, stars
        /// </summary>
        private void UpdateUserProfile(User nUser)
        {
            userInfo.UpdateUserProfile(nUser);
        }

        /// <summary>
        /// update everything when the button is pressed in the 
        /// SetUserDisplay. 
        /// </summary>
        private void NewUserHandler(object sender, RoutedEventArgs e)
        {
            if (!SUserDisplay.search.userID.Equals(currentUser))
            {
                currentUser = SUserDisplay.userIDTextBox.Text;
                LoadUserInformation();
            }
        }

        /// <summary>
        /// Loads new users information into the revelant profile boxes 
        /// </summary>
        public void LoadUserInformation()
        {
            friendList.Clear();
            friendReviewDisplay.displayStackPanel.Children.Clear();
            var nUser = new User();
            GetUserStats(nUser, currentUser); // Fills nUser with values of the currentUser from db
            mgr.CurrentUser = currentUser;
            UpdateUserProfile(nUser);
            LoadUserFriendList(currentUser);
            LoadUserFriendsReview(currentUser);
        }

        /// <summary>
        /// Takes the currentUserID and queries for all of the users
        /// friends and adds them to the friends list.
        /// </summary>
        private void LoadUserFriendList(string userID)
        {
            User nUser;
            // Gets all of the information about the user's friends
            String sql_state = "select userinfo.name, userinfo.average_stars," +
                " userinfo.yelping_since, userinfo.funny, userinfo.cool, userinfo.useful" +
                " from userinfo" +
                " where user_id in (select friend_id from friend where user_id='"+ userID + "')";


            using (var cmd = new NpgsqlCommand(sql_state, connection))
                
            using (var reader = cmd.ExecuteReader())
                // Should only ever return 1 user
                while (reader.Read())
                {
                    nUser = new User();
                    nUser.Name = reader.GetString(0);
                    nUser.AverageStars = reader.GetDouble(1);
                    nUser.YelpSince = reader.GetDateTime(2);
                    nUser.Funny = reader.GetInt32(3);
                    nUser.Cool = reader.GetInt32(4);
                    nUser.Useful = reader.GetInt32(5);
                    AddFriend(nUser);
                }
        }

        private void LoadUserFriendsReview(string userID)
        {
            var reviewList = mgr.ExecuteFriendsLastestReviewQuery(userID);
            foreach (var i in reviewList)
            {
                var name = mgr.ExecuteNameQuery(i.UserID);
                friendReviewDisplay.AddReview(i, name);
            }
        }

        private void LoadFriendReviews(string userID)
        {

        }

        /// <summary>
        /// Gets the User's Name, votes, join date, location,
        /// review count from the db
        /// </summary>
        private void GetUserStats(User nUser, string userID)
        {
            // Gets all of the information about the user
            using (var cmd = new NpgsqlCommand("SELECT name, fans, cool, review_count, funny, useful, " +
                "CAST(average_stars as DOUBLE PRECISION), yelping_since, user_latitude, user_longitute " +
                "FROM userinfo " + "WHERE user_id = '" + userID + "'", connection))

            using (var reader = cmd.ExecuteReader())
                // Should only ever return 1 user
                while (reader.Read())
                {
                    nUser.Name = reader.GetString(0);
                    nUser.Fans = reader.GetInt32(1);
                    nUser.Cool = reader.GetInt32(2);
                    nUser.ReviewCount = reader.GetInt32(3);
                    nUser.Funny = reader.GetInt32(4);
                    nUser.Useful = reader.GetInt32(5);
                    nUser.AverageStars = reader.GetDouble(6);
                    nUser.YelpSince = reader.GetDateTime(7);
                    nUser.Latitude = reader.GetDouble(8);
                    nUser.Longitude = reader.GetDouble(9);
                }
        }


        private void AddFriend(User nUser)
        {
            var nFriend = new FriendDisplayBox(nUser);
            friendList.AddFriendBox(nFriend);
        }

        private void FavoriteBusinessesChanged(object sender, EventArgs e)
        {
            LoadFavoriteBusinesses();
        }

        private void LoadFavoriteBusinesses()
        {
            businessDisplay.favoriteBusinessStackPanel.Children.Clear();
            var busList = mgr.ExecuteFavoriteBusinessQuery();
            businessDisplay.AddFavoriteBusinessDisplayBox(busList);
        }
        


    }
}
