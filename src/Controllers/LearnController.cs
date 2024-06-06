using CoursesSystem.Services;
using CoursesSystem.Views.Lessons;
using CoursesSystem.Models;
using CoursesSystem.Utils;

namespace CoursesSystem.Controllers
{
    public class LearnController
    {
        private readonly EnrollmentService enrollmentService = new EnrollmentService();
        private readonly LessonService lessonService = new LessonService();
        public void Learn(Enrollment enrollment)
        {
            int currentLessonIndex = 0;
            bool isCompleted = false;

            if (enrollment.Progress == 1)
            {
                Helpers.ShowSuccess("You have completed the course! Press Enter to review!");
                isCompleted = true;
            }

            Console.ReadLine();

            List<Lesson> lessons = lessonService.GetLessonByCourse(enrollment.CourseID);
            int numberOfLessons = lessons.Count;

            if (!isCompleted && enrollment.Progress != 0)
                currentLessonIndex  = (int)Math.Round(enrollment.Progress * numberOfLessons) - 1;

            while (true)
            {
                Details.ShowLessonDetails(lessons[currentLessonIndex]);

                if (!isCompleted)
                {
                    enrollment.Progress = (float) (currentLessonIndex + 1) / numberOfLessons;
                    enrollmentService.UpdateStudyProgress(enrollment);
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey(true); 

                switch (keyInfo.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (currentLessonIndex > 0)
                            currentLessonIndex--;
                        break;
                    case ConsoleKey.RightArrow:
                        if (currentLessonIndex < numberOfLessons - 1)
                        {
                            currentLessonIndex++;
                        } else if (!isCompleted)
                                {
                                    Helpers.ShowSuccess("You have completed the course!");
                                    Console.ReadLine();
                                    isCompleted = true;
                                }

                        break;
                    case ConsoleKey.Escape:
                        return;
                }
            }
        }
    }
}