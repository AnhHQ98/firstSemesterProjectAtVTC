using CoursesSystem.Models;
using MySql.Data.MySqlClient;


namespace CoursesSystem.DataAccess
{
    public class PaymentDAL : IRepository <Payment>
    {
        public List<Payment> GetList(int studentId)
        {
            List<Payment> payments = new List<Payment>();

            using (MySqlConnection connection = DBConfig.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Payment WHERE UserID = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", studentId);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Payment payment = new Payment
                        {
                            ID = Convert.ToInt32(reader["PaymentID"]),
                            Amount = Convert.ToDouble(reader["Amount"]),
                            PaymentDate = Convert.ToDateTime(reader["PaymentDate"]),
                            UserID = Convert.ToInt32(reader["UserID"]),
                            CourseID = Convert.ToInt32(reader["CourseID"]),
                            Status = reader["Status"].ToString()
                        };
                        payments.Add(payment);
                    }
                }
            }

            return payments;
        }

        public Payment? GetById(int id)
        {
            Payment? payment = null;

            using (MySqlConnection connection = DBConfig.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Payment WHERE PaymentID = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        payment = new Payment
                        {
                            ID = Convert.ToInt32(reader["PaymentID"]),
                            Amount = Convert.ToDouble(reader["Amount"]),
                            PaymentDate = Convert.ToDateTime(reader["PaymentDate"]),
                            UserID = Convert.ToInt32(reader["UserID"]),
                            CourseID = Convert.ToInt32(reader["CourseID"]),
                            Status = reader["Status"].ToString()
                        };
                    }
                }
            }

            return payment;
        }

        public void Add(Payment item)
        {
            using (MySqlConnection connection = DBConfig.GetConnection())
            {
                connection.Open();
                string query = @"INSERT INTO Payment (UserID, CourseID, Amount, PaymentDate, Status) 
                                VALUES (@UserId, @CourseId, @Amount, @PaymentDate, @Status)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", item.UserID);
                command.Parameters.AddWithValue("@CourseId", item.CourseID);
                command.Parameters.AddWithValue("@Amount", item.Amount);
                command.Parameters.AddWithValue("@PaymentDate", item.PaymentDate);
                command.Parameters.AddWithValue("@Status", item.Status);
                command.ExecuteNonQuery();
            }
        }
        public void Edit(Payment payment) {}
    }
}