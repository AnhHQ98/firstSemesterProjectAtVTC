using System.Security.Cryptography;
using System.Text;
using CoursesSystem.DataAccess;
using CoursesSystem.Models;

namespace CoursesSystem.Services
{
    public class UserService
    {
        private  readonly UserDAL userDAL = new UserDAL();
        public bool CreateUser(User newUser)
        {
            try
            {
                string salt = CreateSalt(8);
                newUser.PasswordHash = GenerateHash(newUser.PasswordHash!, salt);

                userDAL.AddUser(newUser, salt);
                return true;
            } catch {
                return false;
            }
        }

        public bool AuthenticationUser(string username, string password)
        {
            string? salt = userDAL.GetSaltByUsername(username);

            if (salt == null)
            {
                return false;
            }

            return userDAL.AuthenticationAccount(username, GenerateHash(password, salt));
        }
        public User? GetUserByUserName(string username)
        {
            return userDAL.GetByUsername(username);
        }
        public bool EditUserProfile(User user)
        {
            try
            {                
                userDAL.EditProfile(user);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return false;
            }
        }
        public User? GetUserByID(int userId)
        {
            return userDAL.GetByID(userId);
        }

        public void ChangeRole(int userId)
        {
            userDAL.ChangeRole(userId);
        }
        
        private static string CreateSalt(int size)
        {
            var buffer = new byte[size];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(buffer); 
            }

            return Convert.ToBase64String(buffer);
        }

        private static string GenerateHash(string password, string salt)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
                
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}