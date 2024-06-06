using CoursesSystem.Models;
using CoursesSystem.Utils;

namespace CoursesSystem.Views.Courses
{
    public class List
    {
        public bool DisplayCourses(List<Course> courses)
        {
            if (courses == null)
            {
                Helpers.ShowError("No courses to display.");
                return false;
            }

            int currentPage = 0;
            int itemsPerPage = 10;

            ConsoleKeyInfo keyInfo;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\x1b[92m\x1b[1m\x1b[5m" + new string(' ', 65) + " List of all courses\x1b[0m");
                Console.WriteLine("\x1b[30m\x1b[1m" + new string('━', 153) + "\x1b[0m");
                Console.WriteLine($"\x1b[1m▏{"Index",-12} ▏{"Title",-102} ▏{"Price",-20} ▏{"Rating",-11}▕\x1b[0m");
                Console.WriteLine("\x1b[30m\x1b[1m" + new string('━', 153) + "\x1b[0m");

                for (int i = 0; i < itemsPerPage; i++)
                {
                    int index = i + currentPage * itemsPerPage;
                    if (index >= courses.Count) break;
                    Console.WriteLine($"▏{index + 1,-12} ▏{courses[index].Title,-102} ▏{courses[index].Price,-20:C} ▏{courses[index].RatingAverage + "/ 5,0",-11}▕");
                    Console.WriteLine("\x1b[30m\x1b[1m" + new string('━', 153) + "\x1b[0m");
                }

                Console.WriteLine("\x1b[30m\x1b[1m" + new string(' ', 73) + $"<<{currentPage + 1}>>" + new string(' ', 73) + "\x1b[0m");
                Console.WriteLine("\x1b[3m🌟 Use LEFT and RIGHT arrows to navigate, ENTER to select a course, ESC to exit.\x1b[0m");

                keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.RightArrow) currentPage++;
                if (keyInfo.Key == ConsoleKey.LeftArrow) currentPage--;
                if (keyInfo.Key == ConsoleKey.Enter) return true;
                if (keyInfo.Key == ConsoleKey.Escape) return false;

                currentPage = Math.Max(currentPage, 0);
                currentPage = Math.Min(currentPage, (courses.Count - 1) / itemsPerPage);
            }
        }
    }
}