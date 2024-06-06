using CoursesSystem.Utils;

namespace CoursesSystem.Views.Courses
{
    public class CoursesMenu
    {
        public static void CourseManageMenu()
        {
            Console.Clear();
            Helpers.Logo(" COURSE MANAGE  ");

            string[] lines = new string[]
            {
                $"█{new string(' ', 151)}█",
                $"█                                                               \x1b[35m\x1b[1m1. Create course\x1b[33m\x1b[1m                                                                        █",
                $"█{new string(' ', 151)}█",
                $"█{new string('━', 151)}█",
                $"█{new string(' ', 151)}█",
                $"█                                                               \x1b[35m\x1b[1m2. Update course\x1b[33m\x1b[1m                                                                        █",
                $"█{new string(' ', 151)}█",
                $"█{new string('━', 151)}█",
                $"█{new string(' ', 151)}█",
                $"█                                                               \x1b[35m\x1b[1m3. Course list\x1b[33m\x1b[1m                                                                          █",
                $"█{new string(' ', 151)}█",
                $"█{new string('━', 151)}█",
                $"█{new string(' ', 151)}█",
                $"█                                                               \x1b[35m\x1b[1m0. Back to instructor page\x1b[33m\x1b[1m                                                              █",
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