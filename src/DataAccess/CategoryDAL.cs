using CoursesSystem.DataAccess;
using CoursesSystem.Models;
using MySql.Data.MySqlClient;

namespace CoursesSystem.src.DataAccess
{
    public class CategoryDAL
    {
        private MySqlConnection connection = DBConfig.GetConnection();
        public List<Category> GetAll()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            List<Category> categories = new List<Category>();

            string query = @"SELECT * FROM Category";
            MySqlCommand command = new MySqlCommand(query, connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Category category = new Category {
                        ID = Convert.ToInt32(reader["CategoryID"]),
                        Name = reader["Name"].ToString(),
                        Description = reader["Description"].ToString()
                    };

                    categories.Add(category);
                }
            }
            connection.Close();
            return categories;
        }

        public Category? GetCategory(int categoryID)
        {
            Category? category = null;
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            string query = @"SELECT * FROM Category WHERE CategoryID = @categoryId";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@categoryId", categoryID);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    category = new Category {
                        ID = Convert.ToInt32(reader["CategoryID"]),
                        Name = reader["Name"].ToString(),
                        Description = reader["Description"].ToString()
                    };

                }
            }
            connection.Close();
            return category;
        }
    }
}