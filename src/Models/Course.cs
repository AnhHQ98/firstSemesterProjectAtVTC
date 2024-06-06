namespace CoursesSystem.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int InstructorID { get; set; }
        public int CategoryID { get; set; }
        public double Price { get; set; }
        public float RatingAverage { get; set; }
        public string? Level { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}