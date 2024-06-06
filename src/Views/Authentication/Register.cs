using CoursesSystem.Utils;
using CoursesSystem.Controllers;

namespace CoursesSystem.Views.Authentication
{
    public class Register
    {
        public string? Username { get; private set; }
        public string? Password { get; private set; }
        public string? ConfirmPassword { get; private set; }
        public string? Email { get; private set; }
        public string? Phone { get; private set; }

        public void DisplayRegistrationForm()
        {
            AccountController accountController = new AccountController();

            Console.Clear();
            Helpers.Logo("    REGISTER    ");

            do
            {
                Console.Write("\n\x1b[34m\x1b[1m❀  Username: \x1b[0m");
                Username = Console.ReadLine();

                if (string.IsNullOrEmpty(Username))
                   Helpers.ShowError("Username cannot be empty!");
                else if (accountController.CheckUsernameExists(Username))
                        Helpers.ShowError("Username do exists!");
            } while (string.IsNullOrEmpty(Username) || accountController.CheckUsernameExists(Username));

            do
            {
                Console.Write("\n\x1b[34m\x1b[1m❀  Password: \x1b[0m");
                Password = Helpers.InputPassword();
            } while (!Helpers.IsValidPassword(Password));

            do
            {
                Console.Write("\n\x1b[34m\x1b[1m❀  Confirm Password: \x1b[0m");
                ConfirmPassword = Helpers.InputPassword();

                if (ConfirmPassword != Password)
                {
                    Helpers.ShowError("Password confirmation does not match!");
                }
            } while (ConfirmPassword != Password);

            do
            {
                Console.Write("\n\x1b[34m\x1b[1m❀  Email: \x1b[0m");
                Email = Console.ReadLine();

                if (string.IsNullOrEmpty(Email) || !Helpers.IsValidEmail(Email))
                {
                    Helpers.ShowError("Invalid email format!");
                }
            } while (string.IsNullOrEmpty(Email) || !Helpers.IsValidEmail(Email));

            do
            {
                Console.Write("\n\x1b[34m\x1b[1m❀  Phone: \x1b[0m");
                Phone = Console.ReadLine();

                if (string.IsNullOrEmpty(Phone) || !Helpers.IsValidPhoneNumber(Phone))
                {
                    Helpers.ShowError("Invalid phone number format!");
                }
            } while (string.IsNullOrEmpty(Phone) || !Helpers.IsValidPhoneNumber(Phone));
        }
    }
}