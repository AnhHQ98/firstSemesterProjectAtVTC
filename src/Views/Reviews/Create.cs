using CoursesSystem.Utils;

namespace CoursesSystem.Views.Reviews
{
    public class Create
    {
        public int Rating { get; private set; }
        public string? Comment { get; private set; }
        public DateTime DatePosted { get; private set; }
        public void CreateReview()
        {
            Console.Write(" ");
            Console.Write($"\x1b[34m\x1b[1m❀  Enter Rating: \x1b[0m");
            int rating;
            
            while (!int.TryParse(Console.ReadLine(), out rating) || rating < 1 || rating > 5)
            {
                Helpers.ShowError("Invalid rating. Please enter a number between 1 and 5.");
                Console.Write($"\x1b[34m\x1b[1m❀  Enter Rating: \x1b[0m");
            }
            Rating = rating;

            Console.Write($"\x1b[34m\x1b[1m❀  Enter Comment: \x1b[0m");
            Comment = Console.ReadLine();

            DatePosted = DateTime.Now;
        }
    }
}