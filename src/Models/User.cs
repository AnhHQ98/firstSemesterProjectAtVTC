namespace CoursesSystem.Models
{
    public class User
    {
        public int ID { get; set; }
        public string? Username { get; set; }
        public string? PasswordHash{ get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Role { get; set; }
        public DateTime RegisteredDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
    }
}