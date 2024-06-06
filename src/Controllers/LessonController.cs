using CoursesSystem.Services;
using CoursesSystem.Models;
using CoursesSystem.Views.Lessons;

namespace CoursesSystem.Controllers
{
    public class LessonController
    {
        private readonly LessonService lessonService = new LessonService();
        public bool CreateLesson(int courseId)
        {
            try{
            Create create = new Create();
            create.CreateLesson();

            Lesson lesson = new Lesson {
                Title = create.Title,
                VideoURL = create.VideoURL,
                Content = create.Content,
                CourseID = courseId
            };

            lessonService.AddLesson(lesson);
            return true;
            } catch {return false;}
        }
        public bool EditCourse(int lessonId)
        {
            try{
                Lesson? lesson = lessonService.GetByID(lessonId);
                Edit edit = new Edit();
                edit.EditLesson(lesson!);

                lessonService.EditLesson(lesson!);
                return true;
            } catch {return false;}
        }
        public List<Lesson> DisplayAllLessonsForCourse(int courseId)
        {
            List list = new List();
            List<Lesson> lessons = lessonService.GetLessonByCourse(courseId);
            list.ShowLessons(lessons);

            return lessons;
        }
    }
}