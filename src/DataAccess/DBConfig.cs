using MySql.Data.MySqlClient;

namespace CoursesSystem.DataAccess
{
    public class DBConfig
    {
        private static MySqlConnection? connection;
        private static string connectionString = "server=localhost;user id=root;password=123456; port=3306;database=OnlineCourses";

        public static MySqlConnection GetConnection()
        {
            connection = new MySqlConnection(connectionString);
            return connection;
        }

        public static MySqlConnection OpenConnection(){
            if (connection == null){
                GetConnection();
            }
                connection!.Open();
                return connection;
            }
        public static void CloseConnection() {
            if (connection != null)
                connection.Close();
         }
    }
}