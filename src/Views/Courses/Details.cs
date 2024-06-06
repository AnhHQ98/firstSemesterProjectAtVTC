using CoursesSystem.Models;
using CoursesSystem.Utils;
using CoursesSystem.Controllers;

namespace CoursesSystem.Views.Courses
{
    public class Details
    {
        private const int PaddingLength = 130;
        private const string PadCharacter = " ";
        private const string Format = "█\x1b[36m\x1b[1m {0,-20}{1}\x1b[33m\x1b[1m█";

        public static void DisplayCourseDetails(Course course)
        {
            AccountController accountController = new AccountController();
            CategoryController categoryController = new CategoryController();
            ReviewController reviewController = new ReviewController();
            Console.Clear();
            Helpers.Logo(" Course Details ");
            string instructorName = accountController.GetUserByID(course.InstructorID)!.FullName ?? "";
            string categoryName = categoryController.GetCategory(course.CategoryID)!.Name ?? "";

            Console.WriteLine(string.Format(Format, "ID:", PadOrEmpty(course.ID.ToString())));
            Console.WriteLine(string.Format(Format, "Title:", PadOrEmpty(course.Title!)));
            Console.WriteLine(string.Format(Format, "Description:", PadOrEmpty(course.Description!)));
            Console.WriteLine(string.Format(Format, "Price:", PadOrEmpty(course.Price.ToString()), " VND"));
            Console.WriteLine(string.Format(Format, "Instructor:", PadOrEmpty(instructorName)));
            Console.WriteLine(string.Format(Format, "Category:", PadOrEmpty(categoryName)));
            Console.WriteLine(string.Format(Format, "Rating Average:", PadOrEmpty(course.RatingAverage.ToString())));

            Console.WriteLine($"█{new string('▂', 151)}█\n\x1b[0m");
        }

        private static string PadOrEmpty(string value) => value?.PadRight(PaddingLength, PadCharacter[0]) ?? new string(PadCharacter[0], PaddingLength);

        public static void ShowCourseOptionsMenu()
        {
            Console.Clear();
            Helpers.Logo(" COURSE OPTIONS ");

            string[] lines = new string[]
            {
                $"█{new string(' ', 151)}█",
                $"█                                                               \x1b[35m\x1b[1m1. View details\x1b[33m\x1b[1m                                                                         █",
                $"█{new string(' ', 151)}█",
                $"█{new string('━', 151)}█",
                $"█{new string(' ', 151)}█",
                $"█                                                               \x1b[35m\x1b[1m2. View instructor information\x1b[33m\x1b[1m                                                          █",
                $"█{new string(' ', 151)}█",
                $"█{new string('━', 151)}█",
                $"█{new string(' ', 151)}█",
                $"█                                                               \x1b[35m\x1b[1m3. View reviews\x1b[33m\x1b[1m                                                                         █",
                $"█{new string(' ', 151)}█",
                $"█{new string('━', 151)}█",
                $"█{new string(' ', 151)}█",
                $"█                                                               \x1b[35m\x1b[1m4. Buy now\x1b[33m\x1b[1m                                                                              █",
                $"█{new string(' ', 151)}█",
                $"█{new string('━', 151)}█",
                $"█{new string(' ', 151)}█",
                $"█                                                               \x1b[35m\x1b[1m0. Exit\x1b[33m\x1b[1m                                                                                 █",
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