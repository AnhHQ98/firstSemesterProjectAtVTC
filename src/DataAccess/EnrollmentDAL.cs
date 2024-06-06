using CoursesSystem.Models;
using MySql.Data.MySqlClient;

namespace CoursesSystem.DataAccess
{
    public class EnrollmentDAL
    {
        public List<Enrollment> GetList(int studentId)
        {
            List<Enrollment> enrollments = new List<Enrollment>();

            using (MySqlConnection connection = DBConfig.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Enrollment WHERE UserID = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", studentId);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Enrollment enrollment = new Enrollment
                        {
                            ID = Convert.ToInt32(reader["EnrollmentID"]),
                            UserID = Convert.ToInt32(reader["UserID"]),
                            CourseID = Convert.ToInt32(reader["CourseID"]),
                            EnrollmentDate = Convert.ToDateTime(reader["EnrollmentDate"]),
                            Progress = Convert.ToSingle(reader["Progress"])
                        };
                        enrollments.Add(enrollment);
                    }
                }
            }

            return enrollments;
        }

        public Enrollment? GetById(int id)
        {
            Enrollment? enrollment = null;

            using (MySqlConnection connection = DBConfig.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Enrollment WHERE EnrollmentID = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        enrollment = new Enrollment
                        {
                            ID = Convert.ToInt32(reader["EnrollmentID"]),
                            UserID = Convert.ToInt32(reader["UserID"]),
                            CourseID = Convert.ToInt32(reader["CourseID"]),
                            EnrollmentDate = Convert.ToDateTime(reader["EnrollmentDate"]),
                            Progress = Convert.ToSingle(reader["Progress"])
                        };
                    }
                }
            }

            return enrollment;
        }

         public void Add(Enrollment item)
        {
            using (MySqlConnection connection = DBConfig.GetConnection())
            {
                connection.Open();
                string query = @"INSERT INTO Enrollment (UserID, CourseID, EnrollmentDate, Progress) 
                                VALUES (@UserID, @CourseID, @EnrollmentDate, @Progress)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", item.UserID);
                command.Parameters.AddWithValue("@CourseID", item.CourseID);
                command.Parameters.AddWithValue("@EnrollmentDate", item.EnrollmentDate);
                command.Parameters.AddWithValue("@Progress", item.Progress);
                command.ExecuteNonQuery();
            }
        }

        public void Edit(Enrollment item)
        {
            using (MySqlConnection connection = DBConfig.GetConnection())
            {
                connection.Open();
                string query = @"UPDATE Enrollment 
                                SET Progress = @Progress
                                WHERE EnrollmentID = @EnrollmentID";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Progress", item.Progress);
                command.Parameters.AddWithValue("@EnrollmentID", item.ID);
                command.ExecuteNonQuery();
            }
        }
    }
}