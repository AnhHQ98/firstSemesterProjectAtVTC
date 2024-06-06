using CoursesSystem.Models;
using CoursesSystem.Services;
using CoursesSystem.Views.Enrollments;

namespace CoursesSystem.Controllers
{
    public class EnrollmentController
    {
        private readonly EnrollmentService enrollmentService = new EnrollmentService();
        public void CreateEnrollment(int studentId, int courseId)
        {
            Enrollment newEnrollment = new Enrollment
            {
                UserID = studentId,
                CourseID = courseId,
                EnrollmentDate = DateTime.Now,
                Progress = 0
            };

            enrollmentService.CreateEnrollment(newEnrollment);
        }

        public List<Enrollment> DisplayEnrollmentHistory(int studentId)
        {
            List<Enrollment> enrollments = enrollmentService.GetEnrollmentHistory(studentId);
            History history = new History();
            history.DisplayEnrollmentHistory(enrollments);

            return enrollments;
        }
        public bool CheckCourseEnrollmentStatus(int userId, int courseId)
        {
            List<Enrollment> enrollments = enrollmentService.GetEnrollmentHistory(userId);

            foreach (var enrollment in enrollments)
            {
                if (enrollment.CourseID == courseId)
                    return false;
            }

            return true;
        }
    }
}