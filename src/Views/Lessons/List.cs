using CoursesSystem.Models;

namespace CoursesSystem.Views.Lessons
{
    public class List
    {
        public void ShowLessons(List<Lesson> lessons)
        {
            Console.WriteLine("\x1b[92m\x1b[1m\x1b[5m" + new string(' ', 65) + " List of all lessons\x1b[0m");
            Console.WriteLine("\x1b[30m\x1b[1m" + new string('━', 153) + "\x1b[0m");
            Console.WriteLine($"\x1b[1m▏{"Index",-10} ▏{"Title",-44} ▏{"VideoURL",-53} ▏{"Content",-100}\x1b[0m");
            Console.WriteLine("\x1b[30m\x1b[1m" + new string('━', 153) + "\x1b[0m");

            for (int i = 0; i < lessons.Count; i++)
            {
                var lesson = lessons[i];
                Console.WriteLine($"▏{i + 1,-10} ▏{lesson.Title,-44} ▏{lesson.VideoURL,-53} ▏{lesson.Content,-100}");
                Console.WriteLine("\x1b[30m\x1b[1m" + new string('━', 153) + "\x1b[0m");
            }
        }
    }
}