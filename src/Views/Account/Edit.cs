using CoursesSystem.Models;
using CoursesSystem.Utils;

namespace CoursesSystem.Views.Account
{
    public class Edit
    {
        public static void EditUser(User user)
        {
            Console.Clear();
            Helpers.Logo("  Edit Profile  ");

            Console.Write($"\x1b[34m\x1b[1m❀  Full Name ({user.FullName}): \x1b[0m");
            string? fullNameInput = Console.ReadLine()?.Trim();
            user.FullName = string.IsNullOrEmpty(fullNameInput) ? user.FullName : fullNameInput;

            Console.Write($"\x1b[34m\x1b[1m❀  Email ({user.Email}): \x1b[0m");
            string? emailInput = Console.ReadLine()?.Trim();
            user.Email = string.IsNullOrEmpty(emailInput) ? user.Email : emailInput;

            Console.Write($"\x1b[34m\x1b[1m❀  Phone ({user.Phone}): \x1b[0m");
            string? phoneInput = Console.ReadLine()?.Trim();
            user.Phone = string.IsNullOrEmpty(phoneInput) ? user.Phone : phoneInput;

            Console.Write($"\x1b[34m\x1b[1m❀  Date of Birth (YYYY-MM-DD) ({user.DateOfBirth?.ToShortDateString()}): \x1b[0m");
            string? dobInput = Console.ReadLine()?.Trim();
            if (!string.IsNullOrEmpty(dobInput))
            {
                if (DateTime.TryParse(dobInput, out DateTime dob))
                {
                    user.DateOfBirth = dob;
                }
                else
                {
                    Helpers.ShowError("Invalid date format. Please use YYYY-MM-DD.");
                }
            }
        }
    }
}