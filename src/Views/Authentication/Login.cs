using CoursesSystem.Utils;

namespace CoursesSystem.Views.Authentication
{
    public class Login
    {
        public string? Username { get; private set;}
        public string? Password { get; private set;}

        public void DisplayLogin()
        {
            Console.Clear();
            Helpers.Logo("     LOGIN      ");
            
            Console.Write("\n\x1b[34m\x1b[1m❀  Username: \x1b[0m");
            Username = Console.ReadLine();
            
            Console.Write("\x1b[34m\x1b[1m❀  Password: \x1b[0m");
            Password = Helpers.InputPassword();;
        }
    }
}