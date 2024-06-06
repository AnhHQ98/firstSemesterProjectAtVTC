using CoursesSystem.Models;
using MySql.Data.MySqlClient;


namespace CoursesSystem.DataAccess
{
    public class UserDAL
    {
        public User? GetByUsername(string username)
        {
            User? user = null;
            
            try
            {
                using (MySqlConnection connection = DBConfig.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM User WHERE Username = @Username";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                user = new User
                                {
                                    ID = Convert.ToInt32(reader["UserID"]),
                                    Username = reader["Username"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    Phone = reader["Phone"].ToString(),
                                    PasswordHash = reader["PasswordHash"].ToString(),
                                    FullName = reader["FullName"] as string, 
                                    DateOfBirth = reader["DateOfBirth"] != DBNull.Value ? Convert.ToDateTime(reader["DateOfBirth"]) : (DateTime?)null,
                                    Role = reader["Role"].ToString(),
                                    RegisteredDate = Convert.ToDateTime(reader["RegisteredDate"]), 
                                    LastLoginDate = reader["LastLoginDate"] != DBNull.Value ? Convert.ToDateTime(reader["LastLoginDate"]) : (DateTime?)null
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return user;
        }
        
         public User? GetByID(int userId)
        {
            User? user = null;
            
            try
            {
                using (MySqlConnection connection = DBConfig.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM User WHERE UserID = @UserId";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                user = new User
                                {
                                    ID = Convert.ToInt32(reader["UserID"]),
                                    Username = reader["Username"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    Phone = reader["Phone"].ToString(),
                                    PasswordHash = reader["PasswordHash"].ToString(),
                                    FullName = reader["FullName"] as string, 
                                    DateOfBirth = reader["DateOfBirth"] != DBNull.Value ? Convert.ToDateTime(reader["DateOfBirth"]) : (DateTime?)null,
                                    Role = reader["Role"].ToString(),
                                    RegisteredDate = Convert.ToDateTime(reader["RegisteredDate"]), 
                                    LastLoginDate = reader["LastLoginDate"] != DBNull.Value ? Convert.ToDateTime(reader["LastLoginDate"]) : (DateTime?)null
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return user;
        }
        public void AddUser(User item, string salt)
        {
            using (MySqlConnection connection = DBConfig.GetConnection())
            {
                connection.Open();
                string query = @"INSERT INTO User (Username, Email, Phone, Salt, PasswordHash, Role, RegisteredDate) 
                                VALUES (@Username, @Email, @Phone, @Salt, @PasswordHash, @Role, @RegisteredDate)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", item.Username);
                command.Parameters.AddWithValue("@Email", item.Email);
                command.Parameters.AddWithValue("@Salt", salt);
                command.Parameters.AddWithValue("@Phone", item.Phone);
                command.Parameters.AddWithValue("@PasswordHash", item.PasswordHash);
                command.Parameters.AddWithValue("@RegisteredDate", item.RegisteredDate);
                command.Parameters.AddWithValue("@Role", item.Role);

                command.ExecuteNonQuery();
            }
        }

        public void EditProfile(User item)
        {
            using (MySqlConnection connection = DBConfig.GetConnection())
            {
                connection.Open();
                string query = @"UPDATE User 
                                SET Email = @Email, 
                                    Phone = @Phone, 
                                    Role = @Role,
                                    FullName = @FullName,
                                    DateOfBirth = @DateOfBirth
                                WHERE UserID = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", item.Email);
                command.Parameters.AddWithValue("@Phone", item.Phone);
                command.Parameters.AddWithValue("@Role", item.Role);
                command.Parameters.AddWithValue("@FullName", item.FullName);
                command.Parameters.AddWithValue("@DateOfBirth", item.DateOfBirth);
                command.Parameters.AddWithValue("@Id", item.ID);

                command.ExecuteNonQuery();
            }
        }

        public string? GetSaltByUsername(string username)
        {
            string? salt = null;

            try
            {
                using (MySqlConnection connection = DBConfig.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM User WHERE Username = @Username";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                salt = reader["Salt"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return salt;
        }


        public bool AuthenticationAccount(string username, string PasswordHash)
        {
            User? user = GetByUsername(username);
            return user != null && user.PasswordHash == PasswordHash;
        }
        public void ChangeRole(int userId)
        {
            try
            {
                using (MySqlConnection connection = DBConfig.GetConnection())
                {
                    connection.Open();
                    string query = @"UPDATE User 
                                SET Role = @Role
                                WHERE UserID = @Id";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Role", "Instructor");
                    command.Parameters.AddWithValue("@Id", userId);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}