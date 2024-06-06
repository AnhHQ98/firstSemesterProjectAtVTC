namespace CoursesSystem.Models
{    
    public class Lesson
    {
        public int ID { get; set; }
        public int? CourseID { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? VideoURL { get; set; }
    }
}