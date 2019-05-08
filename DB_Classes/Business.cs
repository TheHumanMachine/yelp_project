using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIPractive.DB_Classes
{
    public class Business
    {
        private string businessID;
        private string name;

        private string city;
        private string state;
        private string zipcode;
        private double latitude;
        private double longitude;
        private string address;

        private int reviewCount;
        private int checkInCount;
        private double reviewRating;
        private double stars;
        private double averageScore;
        private string openTime = "N/A";
        private string closeTime = "N/A";

        private double distance = 0;

        private bool isOpen;

        private List<Review> reviews;
        private List<String> categories;
        private List<String> attributes; // Attribute name and value
        private Dictionary<String, Dictionary<String, int>> Checkins; //First string is day, 2nd string is time and integer is the count
        private Dictionary<String, Dictionary<String, String>> hours; //First string is day, 2nd string is open/closed and 3rd string is the time

        public bool IsOpen { get => isOpen; set => isOpen = value; }
        public string City { get => city; set => city = value; }
        public string State { get => state; set => state = value; }
        public string Zipcode { get => zipcode; set => zipcode = value; }
        public double Latitude { get => latitude; set => latitude = value; }
        public double Longitude { get => longitude; set => longitude = value; }
        public string Address { get => address; set => address = value; }
        public int ReviewCount { get => reviewCount; set => reviewCount = value; }
        public int CheckInCount { get => checkInCount; set => checkInCount = value; }
        public double ReviewRating { get => reviewRating; set => reviewRating = value; }
        public double Stars { get => stars; set => stars = value; }
        public double AverageScore { get => averageScore; set => averageScore = value; }
        public string Name { get => name; set => name = value; }
        public string BusinessID { get => businessID; set => businessID = value; }
        public List<string> Categories { get => categories; set => categories = value; }
        public List<string> Attributes { get => attributes; set => attributes = value; }
        public string OpenTime { get => openTime; set => openTime = value; }
        public string CloseTime { get => closeTime; set => closeTime = value; }
        public double Distance { get => distance; set => distance = value; }

        public Business()
        {
            categories = new List<String>();
            attributes = new List<String>();
        }

        public double GetAverageScore()
        {
            return AverageScore;
        }
    }
}
