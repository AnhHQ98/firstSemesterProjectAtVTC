using CoursesSystem.DataAccess;
using CoursesSystem.Models;

namespace CoursesSystem.Services
{
    public class CourseService
    {
        private CourseDAL courseDAL = new CourseDAL();
        public List<Course> GetCoursesByInstructor(int instructorId)
        {
            return courseDAL.GetByInstructorId(instructorId);
        }

        public Course? GetDetailsCourse(int courseId)
        {
            return courseDAL.GetByCourseId(courseId);
        }
        public List<Course> SearchCourses(string? keywords, int categoryId, double? minRating, bool? isFree)
        {
            return courseDAL.GetSearchCourses(keywords, categoryId, minRating, isFree);
        }
        public Course? GetCourseByID(int courseId)
        {
            return courseDAL.GetByCourseId(courseId);
        }
        public bool AddCourse(Course course)
        {
            try
            {
                courseDAL.CreateCourse(course);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return false;
            }
        }
        public bool EditCourse(Course course)
        {
            try
            {
                courseDAL.EditCourse(course);
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