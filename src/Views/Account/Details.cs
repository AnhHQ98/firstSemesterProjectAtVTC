using CoursesSystem.Models;
using CoursesSystem.Utils;

namespace CoursesSystem.Views.Account
{
    public class Details
    {
        private const int PaddingLength = 130;
        private const string PadCharacter = " ";
        private const string Format = "█\x1b[36m\x1b[1m {0,-20}{1}\x1b[33m\x1b[1m█";

        public void ShowUserDetails(User user)
        {
            Console.Clear();
            Helpers.Logo("  User Details  ");

            Console.WriteLine(string.Format(Format, "ID:", PadOrEmpty(user.ID.ToString())));
            Console.WriteLine(string.Format(Format, "Full Name:", PadOrEmpty(user.FullName!)));
            Console.WriteLine(string.Format(Format, "Email:", PadOrEmpty(user.Email!)));
            Console.WriteLine(string.Format(Format, "Phone:", PadOrEmpty(user.Phone!)));
            Console.WriteLine(string.Format(Format, "Date Of Birth:", PadOrEmpty(user.DateOfBirth?.ToShortDateString()!)));
            Console.WriteLine(string.Format(Format, "Role:", PadOrEmpty(user.Role!)));
            Console.WriteLine(string.Format(Format, "Registered Date:", PadOrEmpty(user.RegisteredDate.ToShortDateString())));
            Console.WriteLine($"█{new string('▂', 151)}█\n\x1b[0m");
        }

        private string PadOrEmpty(string value) => value?.PadRight(PaddingLength, PadCharacter[0]) ?? new string(PadCharacter[0], PaddingLength);
    }
}
