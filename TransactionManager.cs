using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using UIPractive.DB_Classes;
using UIPractive.User_View;

namespace UIPractive
{
    public class TransactionManager
    {
        private NpgsqlConnection connection;
        private String currentUser = "";

        public string CurrentUser { get => currentUser; set => currentUser = value; }

        public TransactionManager(NpgsqlConnection conn)
        {
            this.connection = conn;
        }

        public List<CheckIn> ExecuteLatestCheckin(String business_id)
        {
            List<CheckIn> tempList = new List<CheckIn>();
            using (var cmd = new NpgsqlCommand("select *" +
             " from checkins where business_id ='" + business_id + "' order by time", connection))

            using (var reader = cmd.ExecuteReader())
                // Should only ever return 1 user
                while (reader.Read())
                {
                    String day = reader.GetString(0);
                    String count = reader.GetInt32(1).ToString();
                    String time = reader.GetString(2);
                    var temp = new CheckIn(day, count, time);
                    tempList.Add(temp);
                }

            return tempList;
        }

        public void ExecuteQuery(String query)
        {

        }

        public void ExecuteStateQuery(ListBox temp)
        {
            // Gets all of the information about the user
            using (var cmd = new NpgsqlCommand("SELECT DISTINCT(state) From business", connection))

            using (var reader = cmd.ExecuteReader())
                // Should only ever return 1 user
                while (reader.Read())
                {
                    temp.Items.Add(reader.GetString(0));
                }
        }

        public void ExecuteCityQuery(String state, ListBox temp)
        {
            // Gets all of the information about the user
            using (var cmd = new NpgsqlCommand("SELECT DISTINCT(city) From business where state ='" +state+"'", connection))

            using (var reader = cmd.ExecuteReader())
                // Should only ever return 1 user
                while (reader.Read())
                {
                    temp.Items.Add(reader.GetString(0));
                }
        }

        public void ExecuteZipcodeQuery(String state, String city, ListBox temp)
        {
            // Gets all of the information about the user
            using (var cmd = new NpgsqlCommand("SELECT DISTINCT(zipcode) From business where state ='" + state + "' and city ='"+city+"'", connection))

            using (var reader = cmd.ExecuteReader())
                // Should only ever return 1 user
                while (reader.Read())
                {
                    temp.Items.Add(reader.GetInt32(0));
                }
        }

        public List<Business> ExecuteBusinessQuery(int zipcode, string order)
        {
            List<Business> tempList = new List<Business>();
            // Gets all of the information about the user
            using (var cmd = new NpgsqlCommand("SELECT * From business where zipcode=" + zipcode + " order by " + order + " DESC", connection))

            using (var reader = cmd.ExecuteReader())
                // Should only ever return 1 user
                while (reader.Read())
                {
                    var temp = new Business();
                    temp.BusinessID = reader.GetString(0);
                    temp.Name = reader.GetString(1);
                    temp.City = reader.GetString(2);
                    temp.State = reader.GetString(3);
                    temp.Zipcode = reader.GetInt32(4).ToString();
                    temp.Latitude = reader.GetDouble(5);
                    temp.Longitude = reader.GetDouble(6);
                    temp.Address = reader.GetString(7);
                    temp.ReviewCount = reader.GetInt32(8);
                    temp.CheckInCount = 0;
                    temp.IsOpen = Convert.ToBoolean(reader.GetInt32(10));
                    temp.Stars = reader.GetDouble(11);
                    temp.ReviewRating = reader.GetDouble(12);
                    tempList.Add(temp);
                    tempList.Reverse();
                }
            return tempList;
        }

        public List<KeyValuePair<String, int>> ExecuteCheckIn(String businessID)
        {
            var checkinList = new List<KeyValuePair<String, int>>();
            using (var cmd = new NpgsqlCommand("select day, sum(checkins.count)" +
                " from checkins where business_id ='" + businessID + "' group by day", connection))

            using (var reader = cmd.ExecuteReader())
                // Should only ever return 1 user
                while (reader.Read())
                {
                    var checkin = new KeyValuePair<String, int>(reader.GetString(0), reader.GetInt32(1));

                    checkinList.Add(checkin);
                }
            return checkinList;
        }

        public Business ExecuteBusinessQuery(String businessID)
        {
            Business temp = new Business();
            // Gets all of the information about the user
            using (var cmd = new NpgsqlCommand("SELECT * From business where business_id='" + businessID + "'", connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    // Should only ever return 1 user
                    while (reader.Read())
                    {
                        temp.BusinessID = reader.GetString(0);
                        temp.Name = reader.GetString(1);
                        temp.City = reader.GetString(2);
                        temp.State = reader.GetString(3);
                        temp.Zipcode = reader.GetInt32(4).ToString();
                        temp.Latitude = reader.GetDouble(5);
                        temp.Longitude = reader.GetDouble(6);
                        temp.Address = reader.GetString(7);
                        temp.ReviewCount = reader.GetInt32(8);
                        temp.CheckInCount = reader.GetInt32(9);
                        temp.IsOpen = Convert.ToBoolean(reader.GetInt32(10));
                        temp.Stars = reader.GetDouble(11);
                        temp.ReviewRating = reader.GetDouble(12);
                    }
                }
            }


            using (var cmd = new NpgsqlCommand("SELECT category_name From categories where business_id='" + businessID + "'", connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    // Should only ever return 1 user
                    while (reader.Read())
                    {
                        temp.Categories.Add(reader.GetString(0));
                    }
                }
            }

            using (var cmd = new NpgsqlCommand("SELECT attr_name From attributes where business_id='" + businessID + "' and " +
                "value = 'True'", connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    // Should only ever return 1 user
                    while (reader.Read())
                    {
                        temp.Attributes.Add(reader.GetString(0));
                    }
                }
            }

            String day = System.DateTime.Now.DayOfWeek.ToString();

            using (var cmd = new NpgsqlCommand("SELECT open, close From hours where " +
                "business_id='" + businessID + "' and day ='"+day+"'", connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    // Should only ever return 1 user
                    while (reader.Read())
                    {
                        temp.OpenTime = reader.GetString(0);
                        temp.CloseTime = reader.GetString(1);
                    }
                }
            }

            return temp;
        }

        public Boolean IsFavorited(String business_id)
        {
            Boolean isFavorited = false;
            using (var cmd = new NpgsqlCommand("SELECT * From favorite where business_id='" + business_id + "' " +
                "and user_id='"+currentUser+"'", connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    // Should only ever return 1 user
                    while (reader.Read())
                    {
                        isFavorited = true;
                    }
                }
            }
            return isFavorited;
        }

        public List<String> ExecuteCategoryQuery(int zipcode)
        {
            var lTemp = new List<String>();
            // Gets all of the information about the user
            using (var cmd = new NpgsqlCommand("select DISTINCT(category_name) from categories as cat where cat.business_id in (" +
                "SELECT business_id From business where zipcode="+zipcode+")", connection))

            using (var reader = cmd.ExecuteReader())
                // Should only ever return 1 user
                while (reader.Read())
                {
                    lTemp.Add(reader.GetString(0));
                }
            return lTemp;
        }

        public void GetUserCoord(out double lat, out double lon)
        {
            lat = 0;
            lon = 0;
            String sql_statement = "select user_latitude, user_longitute" +
                " from userinfo" +
                " where user_id='" + currentUser + "'";

            using (var cmd = new NpgsqlCommand(sql_statement, connection))

            using (var reader = cmd.ExecuteReader())
                // Should only ever return 1 user
                while (reader.Read())
                {
                    lat = reader.GetDouble(0);
                    lon = reader.GetDouble(1);
                }
        }

        private String BuildAttributesQuery(List<KeyValuePair<String, String>> attr)
        {
            String query = "";
            if (attr.Count > 1)
            {
                query = "business_id in (";
                int parCount = 1;
                for (int i = 0; i < attr.Count; i++)
                {
                    if (i < attr.Count - 1)
                    {
                        parCount++;
                        query += "select business_id from attributes where attr_name ='" + attr.ElementAt(i).Key + "' and value='"+ attr.ElementAt(i).Value + "' and business_id in(";
                    }
                    else
                    {
                        query += "select business_id from attributes where attr_name ='" + attr.ElementAt(i).Key + "'" +
                            " and value='" + attr.ElementAt(i).Value + "'";
                    }
                }
                for (int i = 0; i < parCount; i++)
                {
                    query += ")";
                }

            }
            else
            {
                query = "business_id in (select business_id from attributes where attr_name='" + attr.ElementAt(0).Key + "' and value='"+ attr.ElementAt(0).Value + "')";
            }

            return query;
        }

        private String BuildCategoryQuery(List<String> cat)
        {
            String query = "";
            if (cat.Count > 1)
            {
                query = "name in (";
                int parCount = 1;
                for (int i = 0; i < cat.Count; i++)
                {
                    if (i < cat.Count - 1)
                    {
                        parCount++;
                        query += "select name from business natural join categories where categories.category_name ='" + cat.ElementAt(i) + "' and name in(";
                    }
                    else
                    {
                        query += "select name from business natural join categories where categories.category_name ='" + cat.ElementAt(i) + "'";
                    }
                }
                for (int i = 0; i < parCount; i++)
                {
                    query += ")";
                }
                
            }
            else
            {
                query = "categories.category_name='" + cat.ElementAt(0) + "'";
            }

            return query;
        }

        public List<Business> ExecuteCategoryBusinessQuery(int zipcode, List<String> cat, List<KeyValuePair<String, String>> attr, string order)
        {
            List<Business> tempList = new List<Business>();
            // Gets all of the information about the user
            String orderBy = "DESC";

            // user lat and lon
            double uLat = 0;
            double uLon = 0;

            GetUserCoord(out uLat, out uLon);
            String dist = "round((point(latitude,longitude) <@> point(" + uLat + "," + uLon + "))::numeric, 2) as distance ";

            String query = "";

            query = "select distinct(business_id), name, city, state, zipcode, latitude, longitude, address, review_count, num_checkins, is_open, stars, review_rating," + dist;

            query += "from business natural join categories ";
            query += "where zipcode=" + zipcode + " and ";

            query += BuildCategoryQuery(cat);

            if(attr.Count != 0)
            {
                query += " and " + BuildAttributesQuery(attr);
            }

            if (order == "name" || order == "distance")
            {
                orderBy = "ASC";
            }
            
            query += " order by " + order + " " + orderBy;

            using (var cmd = new NpgsqlCommand(query, connection))

            using (var reader = cmd.ExecuteReader())
                // Should only ever return 1 user
                while (reader.Read())
                {
                    var temp = new Business();
                    temp.BusinessID = reader.GetString(0);
                    temp.Name = reader.GetString(1);
                    temp.City = reader.GetString(2);
                    temp.State = reader.GetString(3);
                    temp.Zipcode = reader.GetInt32(4).ToString();
                    temp.Latitude = reader.GetDouble(5);
                    temp.Longitude = reader.GetDouble(6);
                    temp.Address = reader.GetString(7);
                    temp.ReviewCount = reader.GetInt32(8);
                    temp.CheckInCount = reader.GetInt32(9);
                    temp.IsOpen = Convert.ToBoolean(reader.GetInt32(10));
                    temp.Stars = reader.GetDouble(11);
                    temp.ReviewRating = reader.GetDouble(12);
                    temp.Distance = reader.GetDouble(13);
                    tempList.Add(temp);
                    
                }
            return tempList;
        }

        public void ExecuteUpdateCheckIn(String business_id)
        {
            var day = DateTime.Today.DayOfWeek;
            var dayString = day.ToString();
            var hour = DateTime.Today.Hour;
            var hourString = hour.ToString() + ":00";
            
            Boolean tupleExists = false;
            String sql_statement = "select * from checkins where " +
                "time='" + hourString + "' and " +
                "day='" + dayString + "' and " +
                "business_id='" + business_id + "'";

            using (var cmd = new NpgsqlCommand(sql_statement, connection))
            using (var reader = cmd.ExecuteReader())
                // Should only ever return 1 user
                while (reader.Read())
                {
                    tupleExists = true;
                }

            if (!tupleExists)
            {
                String insertCheckin = "insert into checkins " +
                    "values('" + dayString + "', 1,'" + hourString + "','" + business_id + "')";

                using (var cmd = new NpgsqlCommand(insertCheckin, connection))
                {
                    cmd.ExecuteNonQuery();
                }

            }
            else
            {
                String updateCheckin = "update checkins " +
                    "set count = count + 1" +
                "where " +
                "time='" + hourString + "' and " +
                "day='" + dayString + "' and " +
                "business_id='" + business_id + "'"; ;

                using (var cmd = new NpgsqlCommand(updateCheckin, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }


        }

        public List<Review> ExecuteFriendsLastestReviewQuery(String userID)
        {
            var reviews = new List<Review>();
            using (var cmd = new NpgsqlCommand("select distinct on (user_id) *" +
                "from review " +
                "where user_id in (" +
                    "select friend_id " +
                    "from friend " +
                    "where user_id='" + userID + "'" +
                    ") order by user_id, date DESC", connection))

            using (var reader = cmd.ExecuteReader())
                // Should only ever return 1 user
                while (reader.Read())
                {
                    var rev = new Review();
                    rev.ReviewID = reader.GetString(0);
                    rev.ReviewStars = reader.GetDouble(1);
                    rev.Date = reader.GetDateTime(2).ToShortDateString();
                    rev.Text = reader.GetString(3);
                    rev.UsefulVotes = reader.GetInt32(4);
                    rev.FunnyVotes = reader.GetInt32(5);
                    rev.CoolVotes = reader.GetInt32(6);
                    rev.UserID = reader.GetString(8);
                    reviews.Add(rev);
                }
            return reviews;
        }

        public List<Review> ExecuteBusinessFriendReviewQuery(String businessID)
        {
            var reviews = new List<Review>();
            using (var cmd = new NpgsqlCommand("select * " +
                "from review " +
                "where business_id='"+businessID+"' and user_id in (" +
                    "select friend_id " +
                    "from friend " +
                    "where user_id='" + currentUser + "'" +
                    ") order by user_id, date DESC", connection))

            using (var reader = cmd.ExecuteReader())
                // Should only ever return 1 user
                while (reader.Read())
                {
                    var rev = new Review();
                    rev.ReviewID = reader.GetString(0);
                    rev.ReviewStars = reader.GetDouble(1);
                    rev.Date = reader.GetDateTime(2).ToShortDateString();
                    rev.Text = reader.GetString(3);
                    rev.UsefulVotes = reader.GetInt32(4);
                    rev.FunnyVotes = reader.GetInt32(5);
                    rev.CoolVotes = reader.GetInt32(6);
                    rev.UserID = reader.GetString(8);
                    reviews.Add(rev);
                }
            return reviews;
        }

        public List<Business> ExecuteFavoriteBusinessQuery()
        {
            List<Business> tempList = new List<Business>();
            // Gets all of the information about the user
            using (var cmd = new NpgsqlCommand("SELECT * From business where business_id in(select business_id " +
                "from favorite where user_id='"+currentUser+"')", connection))

            using (var reader = cmd.ExecuteReader())
                // Should only ever return 1 user
                while (reader.Read())
                {
                    var temp = new Business();
                    temp.BusinessID = reader.GetString(0);
                    temp.Name = reader.GetString(1);
                    temp.City = reader.GetString(2);
                    temp.State = reader.GetString(3);
                    temp.Zipcode = reader.GetInt32(4).ToString();
                    temp.Latitude = reader.GetDouble(5);
                    temp.Longitude = reader.GetDouble(6);
                    temp.Address = reader.GetString(7);
                    temp.ReviewCount = reader.GetInt32(8);
                    temp.CheckInCount = reader.GetInt32(9);
                    temp.IsOpen = Convert.ToBoolean(reader.GetInt32(10));
                    temp.Stars = reader.GetDouble(11);
                    temp.ReviewRating = reader.GetDouble(12);
                    tempList.Add(temp);
                    tempList.Reverse();
                }
            return tempList;
        }

        public void ExecuteInsertFavoriteBusiness(String business_id)
        {
            string sql_state = "INSERT INTO favorite(business_id, user_id)" +
                "values('" + business_id + "','" + currentUser + "')";

            using (var cmd = new NpgsqlCommand(sql_state, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public void ExecuteDeleteFavoriteBusiness(String business_id)
        {
            string sql_state = "delete from favorite where business_id='" +
                business_id + "' and user_id='" + currentUser + "'";

            using (var cmd = new NpgsqlCommand(sql_state, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public List<Review> ExecuteBusinessReviewQuery(String businessID)
        {
            var reviews = new List<Review>();
            String sql_statement = "select * " +
                "from review " +
                "where business_id = '" + businessID + "' order by date DESC";

            using (var cmd = new NpgsqlCommand(sql_statement, connection))

            using (var reader = cmd.ExecuteReader())
                // Should only ever return 1 user
                while (reader.Read())
                {
                    var rev = new Review();
                    rev.ReviewID = reader.GetString(0);
                    rev.ReviewStars = reader.GetDouble(1);
                    rev.Date = reader.GetDateTime(2).ToShortDateString();
                    rev.Text = reader.GetString(3);
                    rev.UsefulVotes = reader.GetInt32(4);
                    rev.FunnyVotes = reader.GetInt32(5);
                    rev.CoolVotes = reader.GetInt32(6);
                    rev.UserID = reader.GetString(8);
                    reviews.Add(rev);
                }
            return reviews;
        }

        public String ExecuteNameQuery(String userID)
        {
            String name = "";
            // Gets all of the information about the user
            using (var cmd = new NpgsqlCommand("select name from userinfo where user_id='"+userID+"'", connection))

            using (var reader = cmd.ExecuteReader())
                // Should only ever return 1 user
                while (reader.Read())
                {
                    name= reader.GetString(0);
                }
            return name.ToString();
        }

        public List<String> ExecuteUserQuery(String userName)
        {
            var userIDList = new List<String>();
            using (var cmd = new NpgsqlCommand("select user_id from userinfo where name LIKE '" + userName + "%'", connection))

            using (var reader = cmd.ExecuteReader())
                // Should only ever return 1 user
                while (reader.Read())
                {
                    userIDList.Add(reader.GetString(0));
                }
            return userIDList;
        }

        public List<String> ExecuteBusinessSearchQuery(String businessName)
        {
            var businessIDList = new List<String>();
            using (var cmd = new NpgsqlCommand("select business_id from business where name LIKE '%" + businessName + "%' " +
                "order by business_id DESC", connection))

            using (var reader = cmd.ExecuteReader())
                // Should only ever return 1 user
                while (reader.Read())
                {
                    businessIDList.Add(reader.GetString(0));
                }
            return businessIDList;
        }
        
        public void ExecuteUpdateUserLocation(double lat, double lon)
        {
            string sql_state = "update userinfo" +
                " set user_latitude =" + lat + ", user_longitute ="+lon+"" +
                " where user_id ='"+currentUser+"'";

            using (var cmd = new NpgsqlCommand(sql_state, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public void ExecuteInsertReview(Review rev)
        {
            string sql_state = "INSERT INTO review (review_id,review_stars,date,text,useful_vote,funny_vote,cool_vote,business_id,user_id) VALUES (" +
                "'" + rev.ReviewID + "'," +
                "" + rev.ReviewStars + "," +
                "to_date('2019-28-03','YYYY-DD-MM')," +
                "'" + rev.Text + "'," +
                "" + rev.UsefulVotes + "," +
                "" + rev.FunnyVotes + "," +
                "" + rev.CoolVotes + "," +
                "'" + rev.BusinessID + "'," +
                "'" + currentUser + "')";

            using (var cmd = new NpgsqlCommand(sql_state, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }
        
        public int GetHighestReviewID()
        {
            // Gets all of the information about the user
            int reviewID = 0;
            using (var cmd = new NpgsqlCommand("SELECT COUNT(review_id) From review", connection))

            using (var reader = cmd.ExecuteReader())
                // Should only ever return 1 user
                while (reader.Read())
                {
                    reviewID = reader.GetInt32(0);
                }
            return reviewID;
        }

        public double ExecuteQueryDistance(double uLat, double uLon, double bLat, double bLon)
        {
            double distance = 0;

            String sql_statement = "select round((point(" + uLat + "," + uLon + ") " +
                "<@> point(" + uLat + "," + uLon + "))::numeric, 3)";

            using (var cmd = new NpgsqlCommand(sql_statement, connection))

            using (var reader = cmd.ExecuteReader())
                // Should only ever return 1 user
                while (reader.Read())
                {
                }

            return distance;
        }

    }
}
