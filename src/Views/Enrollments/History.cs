using CoursesSystem.Models;
using CoursesSystem.Controllers;
using CoursesSystem.Utils;

namespace CoursesSystem.Views.Enrollments
{
    public class History
    {
        public void DisplayEnrollmentHistory(List<Enrollment> enrollments)
        {
            CourseController courseController = new CourseController();
            Console.Clear();
            Helpers.Logo("   My Learning  ");
            Console.WriteLine("\x1b[30m\x1b[1m" + new string('━', 153) + "\x1b[0m");
            Console.WriteLine($"\x1b[1m▏{"Index",-15} ▏{"Course Title",-78} ▏{"Enrollment Date",-25} ▏{"Progress",-23}\x1b[0m");
            Console.WriteLine("\x1b[30m\x1b[1m" + new string('━', 153) + "\x1b[0m");

            for (int i = 0; i < enrollments.Count; i++)
            {
                var enrollment = enrollments[i];
                Course? course = courseController.GetCourseByID(enrollment.CourseID);

                Console.WriteLine($"▏{i + 1,-15} ▏{course?.Title,-78} ▏{enrollment.EnrollmentDate.ToShortDateString(),-25} ▏{enrollment.Progress*100 ,-23:F2}");
                Console.WriteLine("\x1b[30m\x1b[1m" + new string('━', 153) + "\x1b[0m");
            }

            if (!enrollments.GetEnumerator().MoveNext())
            {
                Helpers.ShowError("No enrollments found.");
            }

            Console.WriteLine();
        }
    }
}