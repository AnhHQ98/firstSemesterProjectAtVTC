using CoursesSystem.Models;
using CoursesSystem.Views.Courses;
using CoursesSystem.Services;

namespace CoursesSystem.Controllers
{
    public class CourseController
    {
        private readonly CourseService courseService = new CourseService();
        public Course? GetCourseByID(int courseId)
        {
            return courseService.GetCourseByID(courseId);
        }
        public bool CreateCourse(int instructorId)
        {
            try
            {
                Create create = new Create();
                create.CreateCourse();

                Course course = new Course {
                    Title = create.Title,
                    Description = create.Description,
                    InstructorID = instructorId,
                    CategoryID = create.CategoryID,
                    Price = create.Price,
                    RatingAverage = 0,
                    Level = create.Level,
                    CreatedDate = DateTime.Now
                };

                courseService.AddCourse(course);
                return true;
            }
            catch {return false;}
        }

        public bool EditCourse(Course course)
        {
            try{
            Edit edit = new Edit();
            edit.EditCourse(course);

            courseService.EditCourse(course);
            return true;
            } catch {return false;}
        }
        
        public List<Course> DisplayCoursesByInstructor(int instructorId)
        {
            List list = new List();
            List<Course> courses = courseService.GetCoursesByInstructor(instructorId);
            list.DisplayCourses(courses);
            return courses;
        }
        public List<Course> SearchCourses()
        {
            Search search = new Search();
            search.ShowSearchCourse();

            List<Course> courses = courseService.SearchCourses(search.Keywords, search.CategoryID, search.MinRating, search.IsFree);
            return courses;
        }

        public bool  DisplayCourses(List<Course> courses)
        {
            List list = new List();
            if (list.DisplayCourses(courses))
                return true;
            return false;
        }
    }
}