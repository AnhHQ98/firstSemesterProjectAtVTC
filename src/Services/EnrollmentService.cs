using CoursesSystem.Models;
using CoursesSystem.DataAccess;

namespace CoursesSystem.Services
{
    public class EnrollmentService
    {
        private readonly EnrollmentDAL enrollmentDAL = new EnrollmentDAL();

        public void CreateEnrollment(Enrollment enrollment)
        {
            enrollmentDAL!.Add(enrollment);
        }
        public void UpdateStudyProgress(Enrollment enrollment)
        {
            enrollmentDAL!.Edit(enrollment);
        }

        public List<Enrollment> GetEnrollmentHistory(int studentId)
        {
            return enrollmentDAL.GetList(studentId);
        }
    }
}