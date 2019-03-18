using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIPractive.DB_Classes;

namespace UIPractive
{
    public class User
    {
        private string userID;
        private DateTime yelpSince;

        private double latitude;
        private double longitude;

        private int fans;
        private string name;
        private double averageStars;

        private int cool;
        private int funny;
        private int useful;
        private int reviewCount;

        private List<Business> favoriteBusinesses;
        private List<User> friends;
        private List<Review> userReviews;

        public string UserID { get => userID; set => userID = value; }
        public DateTime YelpSince { get => yelpSince; set => yelpSince = value; }
        public double Latitude { get => latitude; set => latitude = value; }
        public double Longitude { get => longitude; set => longitude = value; }
        public int Fans { get => fans; set => fans = value; }
        public string Name { get => name; set => name = value; }
        public double AverageStars { get => averageStars; set => averageStars = value; }
        public int Cool { get => cool; set => cool = value; }
        public int Funny { get => funny; set => funny = value; }
        public int Useful { get => useful; set => useful = value; }
        public int ReviewCount { get => reviewCount; set => reviewCount = value; }

        public void AddReview(Review nReview)
        {
            userReviews.Add(nReview);
        }

        public void RemoveReview(Review nReview)
        {
            userReviews.Remove(nReview);
        }


        public void AddFriend(User nFriend)
        {
            friends.Add(nFriend);
        }

        public void RemoveFriend(User nFriend)
        {
            friends.Remove(nFriend);
        }


        public void RateReview(Review rev, double rating)
        {
            rev.ReviewStars = rating;
        }

        public void WriteReview(Review rev, string text)
        {
            rev.Text = text;
        }

        public void WriteComment(Review rev, Review comment)
        {
            rev.Comments.Add(comment);
        }

    }
}
