namespace CoursesSystem.Models
{
    public class Instructor : User
    {
        public List<Course>? courses { get; set;}
        public Instructor(User user) {
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