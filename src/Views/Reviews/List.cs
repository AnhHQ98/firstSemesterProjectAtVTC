using CoursesSystem.Models;
using CoursesSystem.Controllers;
namespace CoursesSystem.Views.Reviews
{
    public class List
    {
        private readonly AccountController accountController = new AccountController();
        public void ShowReviews(IEnumerable<Review> reviews)
        {
            Console.Clear();
            Console.WriteLine("\x1b[92m\x1b[1m\x1b[5m" + new string(' ', 65) + " Course reviews list\x1b[0m");
            Console.WriteLine("\x1b[30m\x1b[1m" + new string('━', 153) + "\x1b[0m");
            Console.WriteLine($"\x1b[1m▏{"Course ID",-11} ▏{"Username",-12} ▏{"Rating",-11} ▏{"Date Posted",-26} ▏{"Comment",-70}\x1b[0m");
            Console.WriteLine("\x1b[30m\x1b[1m" + new string('━', 153) + "\x1b[0m");

            foreach (var review in reviews)
            {
                User user = accountController.GetUserByID(review.UserID)!;

                Console.WriteLine($"▏{review.CourseID,-11} ▏{user.Username,-12} ▏{review.Rating,-11} ▏{review.DatePosted,-26} ▏{review.Comment,-70}");
                Console.WriteLine("\x1b[30m\x1b[1m" + new string('━', 153) + "\x1b[0m");
            }
        }
    }
}