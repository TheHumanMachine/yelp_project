using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIPractive.DB_Classes
{
    class Business
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

        private bool isOpen;

        private List<Review> reviews;
        private List<String> categories;
        private Dictionary<String, String> attributes; // Attribute name and value
        private Dictionary<String, Dictionary<String, int>> Checkins; //First string is day, 2nd string is time and integer is the count
        private Dictionary<String, Dictionary<String, String>> hours; //First string is day, 2nd string is open/closed and 3rd string is the time

        public bool IsOpen { get => isOpen; set => isOpen = value; }

        public double GetAverageScore()
        {
            return averageScore;
        }
    }
}
