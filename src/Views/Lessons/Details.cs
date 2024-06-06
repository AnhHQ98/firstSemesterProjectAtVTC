using CoursesSystem.Models;
using CoursesSystem.Utils;

namespace CoursesSystem.Views.Lessons
{
    public class Details
    {
        public static void ShowLessonDetails(Lesson lesson)
        {
            Console.Clear();
            Helpers.Logo("    LEARNING    ");
            string videoUrl;
            if (lesson.VideoURL == null) 
                videoUrl = new string(' ', 149);
            else
                videoUrl = lesson.VideoURL.PadRight(149);
            
            string content;
            if (lesson.Content == null) 
                content = new string(' ', 149);
            else
                content = lesson.Content.PadRight(149);

            Console.WriteLine($"█\x1b[42m\x1b[1m{new string(' ', 151)}█");
            Console.WriteLine($"█  {videoUrl}\x1b[33m\x1b[1m█");
            Console.WriteLine($"█{new string(' ', 151)}█");
            Console.WriteLine($"█{new string('━', 151)}█");
            Console.WriteLine($"█{new string(' ', 151)}█");
            Console.WriteLine($"█\x1b[37m\x1b[1m  {content}\x1b[33m\x1b[1m█");
            Console.WriteLine($"█{new string(' ', 151)}█");
            Console.WriteLine($"█{new string(' ', 151)}█");
            Console.WriteLine($"█{new string('━', 151)}█");
            Console.WriteLine($"█                                                          \x1b[39m\x1b[1m[◄ Back] [► Next] [ESC - Exit]\x1b[33m\x1b[1m                                                               █");
            Console.WriteLine($"█{new string('▂', 151)}█\x1b[0m\n");
        }
    }
}