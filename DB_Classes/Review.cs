using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIPractive.DB_Classes
{
    public class Review
    {
        private String reviewID;
        private double reviewStars;
        private String date;
        private String text;
        private double score;
        private int usefulVotes;
        private int funnyVotes;
        private int coolVotes;
        private String userID;
        private String businessID;
        private String businessName = "";

        private List<Review> comments;

        public int FunnyVotes { get => funnyVotes; set => funnyVotes = value; }
        public int UsefulVotes { get => usefulVotes; set => usefulVotes = value; }
        public int CoolVotes { get => coolVotes; set => coolVotes = value; }
        public double ReviewStars { get => reviewStars; set => reviewStars = value; }
        public string Text { get => text; set => text = value; }
        public List<Review> Comments { get => comments; set => comments = value; }
        public string ReviewID { get => reviewID; set => reviewID = value; }
        public string Date { get => date; set => date = value; }
        public string UserID { get => userID; set => userID = value; }
        public String BusinessID { get => businessID; set => businessID = value; }
        public string BusinessName { get => businessName; set => businessName = value; }

        public void AddScore(double score)
        {
            this.score += score;
        }

    }
}
