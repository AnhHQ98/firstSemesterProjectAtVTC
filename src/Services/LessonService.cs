using CoursesSystem.Models;
using CoursesSystem.DataAccess;

namespace CoursesSystem.Services
{
    public class LessonService
    {
        private LessonDAL lessonDAL = new LessonDAL();
        public List<Lesson> GetLessonByCourse(int courseId)
        {
            return lessonDAL.GetList(courseId);
        }
        public Lesson? GetByID(int lessonId)
        {
            return lessonDAL.GetById(lessonId);
        }
        public bool AddLesson(Lesson lesson)
        {
            try
            {
                lessonDAL.Add(lesson);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return false;
            }
        }
        public bool EditLesson(Lesson lesson)
        {
            try
            {
                lessonDAL.Edit(lesson);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return false;
            }
        }
    }
}