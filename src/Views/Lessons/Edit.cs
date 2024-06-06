using CoursesSystem.Models;
using CoursesSystem.Utils;

namespace CoursesSystem.Views.Lessons
{
    public class Edit
    {
        public void EditLesson(Lesson lesson)
        {
            Console.Clear();
            Helpers.Logo("   Edit Lesson  ");

            Console.Write($"\x1b[34m\x1b[1m❀  Enter Lesson Title ({lesson.Title}): \x1b[0m");
            string? titleInput = Console.ReadLine()?.Trim();
            lesson.Title = string.IsNullOrEmpty(titleInput) ? lesson.Title : titleInput;

            Console.Write($"\x1b[34m\x1b[1m❀  Enter Lesson VideoURL ({lesson.VideoURL}): \x1b[0m");
            string? videoUrlInput = Console.ReadLine()?.Trim();
            lesson.VideoURL = string.IsNullOrEmpty(videoUrlInput) ? lesson.VideoURL : videoUrlInput;

            Console.Write($"\x1b[34m\x1b[1m❀  Enter Lesson Content ({lesson.Content}): \x1b[0m");
            string? contentInput = Console.ReadLine()?.Trim();
            lesson.Content = string.IsNullOrEmpty(titleInput) ? lesson.Content : contentInput;
        }
    }
}