using CoursesSystem.Utils;

namespace CoursesSystem.Views.Instructors
{
    public class Dashboard
    {
        public static void ShowDashboard(string name)
        {
                Console.Clear();
                Helpers.Logo("INSTRUCTOR MENU ");
                
                string namePadded;
                if (name == null) 
                    namePadded = new string(' ', 130);
                else
                    namePadded = name.PadRight(130);
                string[] lines = new string[]
                {
                    $"█{new string(' ', 151)}█",
                    $"█  \x1b[34m\x1b[1m💗 Welcome back 💗 {namePadded}\x1b[33m\x1b[1m█",
                    $"█{new string(' ', 151)}█",
                    $"█{new string('━', 151)}█",
                    $"█{new string(' ', 151)}█",
                    $"█                                                               \x1b[35m\x1b[1m1. Review list\x1b[33m\x1b[1m                                                                          █",
                    $"█{new string(' ', 151)}█",
                    $"█{new string('━', 151)}█",
                    $"█{new string(' ', 151)}█",
                    $"█                                                               \x1b[35m\x1b[1m2. Course management\x1b[33m\x1b[1m                                                                    █",
                    $"█{new string(' ', 151)}█",
                    $"█{new string('━', 151)}█",
                    $"█{new string(' ', 151)}█",
                    $"█                                                               \x1b[35m\x1b[1m0. Back to main\x1b[33m\x1b[1m                                                                         █",
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