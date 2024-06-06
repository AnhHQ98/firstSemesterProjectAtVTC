using CoursesSystem.Views.Authentication;
using CoursesSystem.Services;
using CoursesSystem.Models;
using CoursesSystem.Views.Account;

namespace CoursesSystem.Controllers
{
    public class AccountController
    {
        private readonly UserService userService = new UserService();

        public bool Register()
        {
            Register register = new Register();
            register.DisplayRegistrationForm();

            User user = new User {
                Username = register.Username,
                PasswordHash = register.Password,
                Email = register.Email,
                Phone = register.Phone,
                RegisteredDate = DateTime.Now,
                Role = "Student"
            };
           
           if (userService.CreateUser(user))
                return true;
            else return false;
        }

        public User? Login()
        {
            Login login = new Login();
            login.DisplayLogin();

            if (userService.AuthenticationUser(login.Username!, login.Password!))
                return userService.GetUserByUserName(login.Username!)!;
            
            return null;
        }
        public bool EditProfile(User user)
        {
            Edit.EditUser(user);

            if (userService.EditUserProfile(user))
                return true;
            
            return false;
        }
        public void ChangeRoleToInstructor(int userId)
        {
            userService.ChangeRole(userId);
        }
        public void UserDetails(string username)
        {
            User user = userService.GetUserByUserName(username)!;

            Details details = new Details();
            details.ShowUserDetails(user);
        }
        public User? GetUserByID(int userId)
        {
            return userService.GetUserByID(userId);
        }
        public bool CheckUsernameExists(string username)
        {
            
            if (userService.GetUserByUserName(username) == null)
                return false;
            
            return true;
        }
    }
}