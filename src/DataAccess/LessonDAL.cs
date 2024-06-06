using CoursesSystem.Models;
using MySql.Data.MySqlClient;

namespace CoursesSystem.DataAccess
{
    public class LessonDAL : IRepository<Lesson>
    {
        public List<Lesson> GetList(int courseId)
        { 
            List<Lesson> lessons = new List<Lesson>();

            using (MySqlConnection connection = DBConfig.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Lesson WHERE CourseID = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", courseId);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Lesson lesson = new Lesson
                        {
                            ID = Convert.ToInt32(reader["LessonID"]),
                            CourseID = Convert.ToInt32(reader["CourseID"]),
                            Title = reader["Title"].ToString(),
                            VideoURL = reader["VideoURL"].ToString(),
                            Content = reader["Content"].ToString()
                        };
                        lessons.Add(lesson);
                    }
                }
            }

            return lessons;
        }

        public Lesson? GetById(int id)
        {
            Lesson? lesson = null;

            using (MySqlConnection connection = DBConfig.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Lesson WHERE LessonID = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lesson = new Lesson
                        {
                            ID = Convert.ToInt32(reader["LessonID"]),
                            CourseID = Convert.ToInt32(reader["CourseID"]),
                            Title = reader["Title"].ToString(),
                            VideoURL = reader["VideoURL"].ToString(),
                            Content = reader["Content"].ToString()
                        };
                    }
                }
            }

            return lesson;
        }

        public void Add(Lesson item)
        {
            using (MySqlConnection connection = DBConfig.GetConnection())
            {
                connection.Open();
                string query = @"INSERT INTO Lesson (CourseID, Title, VideoURL, Content) 
                                VALUES (@CourseID, @Title, @VideoURL, @Content)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@CourseID", item.CourseID);
                command.Parameters.AddWithValue("@Title", item.Title);
                command.Parameters.AddWithValue("@VideoURL", item.VideoURL);
                command.Parameters.AddWithValue("@Content", item.Content);
                command.ExecuteNonQuery();
            }
        }

        public void Edit(Lesson item)
        {
            using (MySqlConnection connection = DBConfig.GetConnection())
            {
                connection.Open();
                string query = @"UPDATE Lesson 
                                SET Title = @Title, 
                                    VideoURL = @VideoURL
                                WHERE LessonID = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Title", item.Title);
                command.Parameters.AddWithValue("@VideoURL", item.VideoURL);
                command.Parameters.AddWithValue("@Content", item.Content);
                command.Parameters.AddWithValue("@Id", item.ID);
                command.ExecuteNonQuery();
            }
        }
    }
}