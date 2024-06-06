namespace CoursesSystem.Models
{
    public class Enrollment
    {
        public int ID { get; set; }
        public int CourseID { get; set; }
        public int UserID { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public float Progress { get; set; }
    }
}