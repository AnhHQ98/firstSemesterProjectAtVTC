using CoursesSystem.Models;
using MySql.Data.MySqlClient;


namespace CoursesSystem.DataAccess
{
    public class ReviewDAL
    {
        public List<Review> GetList(int courseId)
        {
            List<Review> reviews = new List<Review>();

            using (MySqlConnection connection = DBConfig.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Review WHERE CourseID = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", courseId);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Review review = new Review
                        {
                            CourseID = Convert.ToInt32(reader["CourseID"]),
                            ID = Convert.ToInt32(reader["ReviewID"]),
                            Rating = Convert.ToInt32(reader["Rating"]),
                            Comment = reader["Comment"].ToString()!,
                            UserID = Convert.ToInt32(reader["UserID"]),
                            DatePosted = Convert.ToDateTime(reader["ReviewDate"])
                        };
                        reviews.Add(review);
                    }
                }
            }

            return reviews;
        }

        public List<Review> GetAllReviewsForInstructor(int instructorId)
        {
            var reviews = new List<Review>();
            using (MySqlConnection connection = DBConfig.GetConnection())
            {
                try
                {
                    connection.Open();
                    
                    using (var cmd = new MySqlCommand("GetAllReviewsForInstructor", connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("instructorId", instructorId);
                        
                        using (var reader = cmd.ExecuteReader())
                        {
                            while  (reader.Read())
                            {
                                 reviews.Add(new Review
                                {
                                    ID = reader.GetInt32("ReviewID"),
                                    CourseID = reader.GetInt32("CourseID"),
                                    UserID = reader.GetInt32("UserID"),
                                    Rating = reader.GetInt32("Rating"),
                                    Comment = reader.GetString("Comment"),
                                    DatePosted = reader.GetDateTime("ReviewDate")
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
            return reviews;
        }

        public Review? GetById(int id)
        {
            Review? review = null;

            using (MySqlConnection connection = DBConfig.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Review WHERE ReviewID = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        review = new Review
                        {
                            CourseID = Convert.ToInt32(reader["CourseID"]),
                            ID = Convert.ToInt32(reader["ReviewID"]),
                            Rating = Convert.ToInt32(reader["Rating"]),
                            Comment = reader["Comment"].ToString()!,
                            UserID = Convert.ToInt32(reader["UserID"]),
                            DatePosted = Convert.ToDateTime(reader["ReviewDate"])
                        };
                    }
                }
            }
            
            return review;
        }

        public void Add(Review item)
        {
            using (MySqlConnection connection = DBConfig.GetConnection())
            {
                connection.Open();
                string query = @"INSERT INTO Review (CourseID, UserID, Rating, Comment, ReviewDate) 
                                VALUES (@CourseID, @UserID, @Rating, @Comment, @ReviewDate)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@CourseID", item.CourseID);
                command.Parameters.AddWithValue("@UserID", item.UserID);
                command.Parameters.AddWithValue("@Rating", item.Rating);
                command.Parameters.AddWithValue("@Comment", item.Comment);
                command.Parameters.AddWithValue("@ReviewDate", item.DatePosted);
                command.ExecuteNonQuery();
            }
        }

        public void Edit(Review item)
        {
            using (MySqlConnection connection = DBConfig.GetConnection())
            {
                connection.Open();
                string query = @"UPDATE Review 
                                SET Rating = @Rating, Comment = @Comment
                                WHERE ReviewID = @ReviewID";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Rating", item.Rating);
                command.Parameters.AddWithValue("@Comment", item.Comment);
                command.Parameters.AddWithValue("@ReviewID", item.ID);
                command.ExecuteNonQuery();
            }
        }
    }
}