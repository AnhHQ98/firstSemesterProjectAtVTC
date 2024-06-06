using CoursesSystem.Utils;

namespace CoursesSystem.Views.Account
{
    public class MenuAccount
    {
        public static void ShowMenu()
        {
                Console.Clear();
                Helpers.Logo("    USER MENU   ");

                string[] lines = new string[]
            {
                $"█{new string(' ', 151)}█",
                $"█                                                               \x1b[35m\x1b[1m1. Public profile\x1b[33m\x1b[1m                                                                       █",
                $"█{new string(' ', 151)}█",
                $"█{new string('━', 151)}█",
                $"█{new string(' ', 151)}█",
                $"█                                                               \x1b[35m\x1b[1m2. Edit profile\x1b[33m\x1b[1m                                                                         █",
                $"█{new string(' ', 151)}█",
                $"█{new string('━', 151)}█",
                $"█{new string(' ', 151)}█",
                $"█                                                               \x1b[35m\x1b[1m3. Payment history\x1b[33m\x1b[1m                                                                      █",
                $"█{new string(' ', 151)}█",
                $"█{new string('━', 151)}█",
                $"█{new string(' ', 151)}█",
                $"█                                                               \x1b[35m\x1b[1m4. Back to main menu\x1b[33m\x1b[1m                                                                    █",
                $"█{new string(' ', 151)}█",
                $"█{new string('━', 151)}█",
                $"█{new string(' ', 151)}█",
                $"█                                                               \x1b[35m\x1b[1m5. Logout\x1b[33m\x1b[1m                                                                               █",
                $"█{new string(' ', 151)}█",
                $"█{new string('▂', 151)}█\n\x1b[0m",
            };
        foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }
}