namespace CoursesSystem.Models
{
    public class Payment
    {
        public int ID { get; set; }
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int UserID { get; set; }
        public int CourseID { get; set; }
        public string? Status { get; set; }
    }
}