using CoursesSystem.Utils;

namespace CoursesSystem.Views.Lessons
{
    public class Create
    {
        public string? Title { get; private set; }
        public string? VideoURL { get; private set; }
        public string? Content { get; private set; }
        public void CreateLesson()
        {
            Console.Clear();
            Helpers.Logo(" Create Lesson  ");

            Console.Write("\x1b[34m\x1b[1m❀  Enter Title: \x1b[0m");
            string? title = Console.ReadLine()?.Trim();

            while (string.IsNullOrEmpty(title))
            {
                Console.WriteLine("\x1b[31mTitle cannot be empty. Please enter a title.\x1b[0m");
                Console.Write("\x1b[34m\x1b[1m❀  Enter Title: \x1b[0m");
                title = Console.ReadLine()?.Trim();
            }
            Title = title;

            Console.Write($"\x1b[34m\x1b[1m❀  Enter VideoURL: \x1b[0m");
            string? videoUrl = Console.ReadLine()?.Trim();

            while (string.IsNullOrEmpty(videoUrl))
            {
                Console.WriteLine("\x1b[31mVideoURL cannot be empty. Please enter a videoURL.\x1b[0m");
                Console.Write("\x1b[34m\x1b[1m❀  Enter VideoURL: \x1b[0m");
                videoUrl = Console.ReadLine()?.Trim();
            }
            VideoURL = videoUrl;

            Console.Write($"\x1b[34m\x1b[1m❀  Enter Content: \x1b[0m");
            string? content = Console.ReadLine()?.Trim();

            while (string.IsNullOrEmpty(content))
            {
                Console.WriteLine("\x1b[31mContent cannot be empty. Please enter a content.\x1b[0m");
                Console.Write("\x1b[34m\x1b[1m❀  Enter Content: \x1b[0m");
                content = Console.ReadLine()?.Trim();
            }
            Content = content;
        }
    }
}