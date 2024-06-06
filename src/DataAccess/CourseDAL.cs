using MySql.Data.MySqlClient;
using CoursesSystem.Models;

namespace CoursesSystem.DataAccess
{
    public class CourseDAL
    {
        private MySqlConnection connection = DBConfig.GetConnection();
        public List<Course> GetAll()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            List<Course> courses = new List<Course>();

            string query = @"SELECT * FROM Course";
            MySqlCommand command = new MySqlCommand(query, connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Course course = new Course
                    {
                        ID = Convert.ToInt32(reader["CourseID"]),
                        Title = reader["Title"].ToString(),
                        Description = reader["Description"].ToString(),
                        CategoryID = Convert.ToInt32(reader["CategoryID"]),
                        Price = Convert.ToDouble(reader["Price"]),
                        InstructorID = Convert.ToInt32(reader["InstructorID"]),
                        RatingAverage = Convert.ToSingle(reader["RatingAverage"]),
                        Level = reader["Level"].ToString(), 
                        CreatedDate = Convert.ToDateTime(reader["CreatedDate"]), 
                        UpdatedDate = reader["UpdatedDate"] != DBNull.Value ? Convert.ToDateTime(reader["UpdatedDate"]) : (DateTime?)null
                    };
                    courses.Add(course);
                }
            }
            connection.Close();
            return courses;
        }

        public List<Course> GetByInstructorId(int instructorId)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            List<Course> courses = new List<Course>();

            string query = @"SELECT * FROM Course WHERE InstructorID = @Id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", instructorId);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Course course = new Course
                    {
                        ID = Convert.ToInt32(reader["CourseID"]),
                        Title = reader["Title"].ToString(),
                        Description = reader["Description"].ToString(),
                        CategoryID = Convert.ToInt32(reader["CategoryID"]),
                        Price = Convert.ToDouble(reader["Price"]),
                        InstructorID = Convert.ToInt32(reader["InstructorID"]),
                        RatingAverage = Convert.ToSingle(reader["RatingAverage"]),
                        Level = reader["Level"].ToString(), 
                        CreatedDate = Convert.ToDateTime(reader["CreatedDate"]), 
                        UpdatedDate = reader["UpdatedDate"] != DBNull.Value ? Convert.ToDateTime(reader["UpdatedDate"]) : (DateTime?)null
                    };
                    courses.Add(course);
                }
            }
            connection.Close();
            return courses;
        }

        public Course? GetByCourseId(int courseId)
        {
            Course? course = null;

            using (MySqlConnection connection = DBConfig.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Course WHERE CourseID = @Id";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", courseId);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                course = new Course
                                {
                                    ID = Convert.ToInt32(reader["CourseID"]),
                                    Title = reader["Title"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    CategoryID = Convert.ToInt32(reader["CategoryID"]),
                                    Price = Convert.ToDouble(reader["Price"]),
                                    InstructorID = Convert.ToInt32(reader["InstructorID"]),
                                    RatingAverage = Convert.ToSingle(reader["RatingAverage"]),
                                    Level = reader["Level"].ToString(), 
                                    CreatedDate = Convert.ToDateTime(reader["CreatedDate"]), 
                                    UpdatedDate = reader["UpdatedDate"] != DBNull.Value ? Convert.ToDateTime(reader["UpdatedDate"]) : (DateTime?)null
                                };
                                        }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error occurred: " + ex.Message);
                }
            }

            return course;
        }

        public List<Course> GetSearchCourses(string? keywords, int categoryId, double? minRating, bool? isFree)
        {
            List<Course> courses = new List<Course>();
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            string query = "SELECT * FROM Course WHERE 1=1"; 

            if (!string.IsNullOrEmpty(keywords))
            {
                query += " AND Title LIKE @Keywords";
                parameters.Add(new MySqlParameter("@Keywords", $"%{keywords}%"));
            }

            if (categoryId > 0)
            {
                query += " AND CategoryID = @CategoryId";
                parameters.Add(new MySqlParameter("@CategoryId", categoryId));
            }

            if (minRating.HasValue)
            {
                query += " AND RatingAverage >= @MinRating";
                parameters.Add(new MySqlParameter("@MinRating", minRating));
            }

            if (isFree.HasValue)
            {
                query += isFree.Value ? " AND Price = 0" : " AND Price > 0";
            }

            using (var connection = DBConfig.GetConnection())
            {
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters.ToArray());
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Course course = new Course
                            {
                                ID = Convert.ToInt32(reader["CourseID"]),
                                Title = reader["Title"].ToString(),
                                Description = reader["Description"].ToString(),
                                CategoryID = Convert.ToInt32(reader["CategoryID"]),
                                Price = Convert.ToDouble(reader["Price"]),
                                InstructorID = Convert.ToInt32(reader["InstructorID"]),
                                RatingAverage = Convert.ToSingle(reader["RatingAverage"]),
                                Level = reader["Level"].ToString(), 
                                CreatedDate = Convert.ToDateTime(reader["CreatedDate"]), 
                                UpdatedDate = reader["UpdatedDate"] != DBNull.Value ? Convert.ToDateTime(reader["UpdatedDate"]) : (DateTime?)null
                            };
                            courses.Add(course);
                        }
                    }
                }
            }

            return courses;
        }

        public void CreateCourse(Course course)
        {
            using (var connection = DBConfig.GetConnection()) 
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = "sp_createCourse";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("p_Title", course.Title);
                        command.Parameters.AddWithValue("p_Description", course.Description);
                        command.Parameters.AddWithValue("p_Price", course.Price);
                        command.Parameters.AddWithValue("p_InstructorID", course.InstructorID);
                        command.Parameters.AddWithValue("p_CategoryID", course.CategoryID); 
                        command.Parameters.AddWithValue("p_Rating", course.RatingAverage);
                        command.Parameters.AddWithValue("p_Level", course.Level); 
                        command.Parameters.AddWithValue("p_CreatedDate", course.CreatedDate);

                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error occurred: " + ex.Message);
                    }
                }
            }
        }

        
        public void EditCourse(Course course)
        {
            using (MySqlConnection connection = DBConfig.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = @"UPDATE Course 
                                    SET Title = @Title, Description = @Description, 
                                        Price = @Price, Level = @Level, UpdatedDate = @UpdatedDate
                                    WHERE CourseID = @Id";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Title", course.Title);
                    command.Parameters.AddWithValue("@Description", course.Description);
                    command.Parameters.AddWithValue("@Price", course.Price);
                    command.Parameters.AddWithValue("@Level", course.Level);
                    command.Parameters.AddWithValue("@UpdatedDate", DateTime.Now);
                    command.Parameters.AddWithValue("@Id", course.ID);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }

    }
}