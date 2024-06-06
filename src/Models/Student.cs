
namespace CoursesSystem.Models
{
    public class Student : User
    {
        public List<Enrollment>? enrollments { get; set; }
        public Student(User user) {
        this.ID = user.ID;
        this.Username = user.Username;
        this.PasswordHash = user.PasswordHash;
        this.Email = user.Email;
        this.Phone = user.Phone;
        this.FullName = user.FullName;
        this.DateOfBirth = user.DateOfBirth;
        this.Role = user.Role;
        this.RegisteredDate = user.RegisteredDate;
        this.LastLoginDate = user.LastLoginDate;
    }
    }
}