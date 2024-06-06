using CoursesSystem.Utils;
using CoursesSystem.Controllers;
using CoursesSystem.Models;
using CoursesSystem.Views.Account;
using CoursesSystem.Views.Instructors;
using CoursesSystem.Views.Courses;

public class Program
{
    private static AccountController accountController = new AccountController();
    private static PaymentController paymentController = new PaymentController();
    private static CourseController courseController = new CourseController();
    private static EnrollmentController enrollmentController = new EnrollmentController();
    private static ReviewController reviewController = new ReviewController();
    private static LessonController lessonController = new LessonController();
    private static LearnController learnController = new LearnController();
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Helpers.Logo("   GUEST PAGE   ");
            ShowFirstMenu();

            Console.Write("\x1b[36m\x1b[1m  Choice: \x1b[0m");
            string choose = Console.ReadLine() ?? " ";
            switch (choose)
            {
                case "1":
                    User? user = accountController.Login();
                    if (user != null)
                    {
                        Helpers.ShowSuccess("Logged in successfully!");
                        Console.ReadLine();
                        HomePage(user);
                    }
                    else Helpers.ShowError("Login failed. Username or password is incorrect!");
                    Console.ReadLine();

                    break;
                case "2":
                    if (accountController.Register())
                        Helpers.ShowSuccess("Account registration successful!");
                    Console.ReadLine();

                    break;
                case "3":
                    List<Course> courses = courseController.SearchCourses();
                    while (true)
                    {
                        if (courseController.DisplayCourses(courses))
                        {
                            Console.Write("Choice Index (Enter 0 to exit): ");
                            string? indexCourseInput = Console.ReadLine();
                            int indexCourse;

                            if (int.TryParse(indexCourseInput, out indexCourse))
                            {
                                if (indexCourse == 0) break;
                                else if (courses.Count < indexCourse || indexCourse < 1)
                                        Helpers.ShowError("Invalid index!");
                                        else {
                                            CourseOptions(courses[indexCourse-1], null);
                                        }
                            } else Helpers.ShowError("Invalid index!");
                            Console.ReadLine();
                        } else break;
                    }

                    break;
                default:
                    Helpers.ShowError("Invalid selection!");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void HomePage(User? user)
    {
        while (true)
        {
            Console.Clear();
            Helpers.Logo("    HOME PAGE   ");
            ShowMainMenu();
            
            Console.Write("\x1b[36m\x1b[1m  Choose: \x1b[0m");
            string choose = Console.ReadLine() ?? " ";

            switch (choose)
            {
                case "1":
                    UserPage(user!);
                    break;
                case "2":
                    List<Course> courses = courseController.SearchCourses();
                    while (true)
                    {
                        if (courseController.DisplayCourses(courses))
                        {
                            Console.Write("Choice Index (Enter 0 to exit): ");
                            string? indexCourseInput = Console.ReadLine();
                            int indexCourse;

                            if (int.TryParse(indexCourseInput, out indexCourse))
                            {
                                if (indexCourse == 0) break;
                                else if (courses.Count < indexCourse || indexCourse < 1)
                                        Helpers.ShowError("Invalid index!");
                                        else {
                                            CourseOptions(courses[indexCourse-1], user!);
                                        }
                            } else Helpers.ShowError("Invalid index!");
                            Console.ReadLine();
                        } else break;
                    }
                    
                    break;
                case "3":
                    Student student = new Student(user!);
                    MyCourses(student!);
                    Console.ReadLine();
                    break;
                case "4":
                    Instructor instructor = new Instructor(user!);
                
                    if (user!.Role == "Instructor")
                        InstructorPage(instructor!);
                    else {
                        Console.Write("Not registered as an instructor yet, register now? (Y/N): ");
                        string isReg = Console.ReadLine() ?? " ";
                        if (isReg == "Y" || isReg =="y")
                        {
                            user.Role = "Instructor";
                            accountController.ChangeRoleToInstructor(user.ID);
                            InstructorPage(instructor!);
                        }
                    }
                    break;
                default:
                    Helpers.ShowError("Invalid selection!");
                    break;
            }
        }
    }
    public static void MyCourses(Student student)
    {
        while (true)
        {
            List<Enrollment> enrollments = enrollmentController.DisplayEnrollmentHistory(student!.ID);

            Console.Write("\x1b[36m\x1b[1m  Choose index (Enter 0 to exit): \x1b[0m");
            string indexEnrollmentInput = Console.ReadLine() ?? " ";
            int indexEnrollment;

            if (int.TryParse(indexEnrollmentInput, out indexEnrollment))
            {
                if (indexEnrollment == 0) return;
                else if (enrollments.Count < indexEnrollment || indexEnrollment < 1)
                        Helpers.ShowError("Invalid index!");
                        else {
                            if (!reviewController.CheckCourseEvaluation(enrollments[indexEnrollment-1].CourseID, student.ID) && enrollments[indexEnrollment-1].Progress > 0.1)
                            {
                                Console.Write("\x1b[36m\x1b[1mPress any key to learn or press * to evaluate the course: \x1b[0m");
                                string? choose = Console.ReadLine();

                                if (choose == "*")
                                {
                                    if (reviewController.CreateReview(student.ID, enrollments[indexEnrollment-1].CourseID))
                                        Helpers.ShowSuccess("Successful!");;
                                }
                            }
                            
                            learnController.Learn(enrollments[indexEnrollment-1]);
                        }
            } else {
                Helpers.ShowError("Invalid index!");
                Console.ReadLine();
            }
        }
    }
    private static void CourseOptions(Course course, User? user)
    {
        while (true)
        {
            CoursesSystem.Views.Courses.Details.ShowCourseOptionsMenu();
            Console.Write("\x1b[36m\x1b[1m  Choose: \x1b[0m");
            string choice = Console.ReadLine() ?? " ";
            switch (choice)
            {
                case "1":
                    CoursesSystem.Views.Courses.Details.DisplayCourseDetails(course);
                    break;
                case "2":
                    User instructor = accountController.GetUserByID(course.InstructorID)!;
                    accountController.UserDetails(instructor.Username!);
                    break;
                case "3":
                    reviewController.DisplayReviewsByCourseId(course.ID);
                    break;
                case "4":
                    if (user != null)
                    {
                        if (course.InstructorID == user.ID)
                            Helpers.ShowError("This is your course!");
                            else if (!enrollmentController.CheckCourseEnrollmentStatus(user.ID ,course.ID))
                                Helpers.ShowError("Previously enrolled in this course!");
                                else if (paymentController.MakePayment(course, user.ID))
                                        {
                                            Helpers.ShowSuccess("Successfully purchased the course!");

                                            string toEmail = user.Email!;
                                            string subject = "Course Registration Confirmation";

                                            string body = $"Hello {user.FullName}, welcome to '{course.Title}' at CV Online starting on {DateTime.Now.ToShortDateString()}. For questions, reach out to nickycv@gmail.com. Thanks, CV Online Team";
                                            
                                            if (Helpers.SendEmail(toEmail, subject, body))
                                                Helpers.ShowSuccess("Please check email!");
                                        }
                                    else Helpers.ShowError("Payment failed!");
                    } else Helpers.ShowError("Not logged in yet!");

                    break;
                case "0":
                    return;
                default:
                    Helpers.ShowError("Invalid choice!");
                    break;
            }
            Console.ReadLine();
        }
    }
    private static void UserPage(User? user)
    {
        while (true)
        {
            MenuAccount.ShowMenu();

            Console.Write("\x1b[36m\x1b[1m  Choose: \x1b[0m");
            string choice = Console.ReadLine() ?? " ";

            switch (choice)
            {
                case "1":
                accountController.UserDetails(user?.Username!);
                Console.ReadLine();
                break;
                case "2":
                    if (accountController.EditProfile(user!))
                    {
                        Helpers.ShowSuccess("Information changed successfully!");
                    }
                    Console.ReadLine();
                    break;
                case "3":
                    paymentController.DisplayPaymentHistory(user!.ID);
                    Console.ReadLine();
                    break;
                case "4":
                    return;
                case "5":
                    user = null;
                    Main();
                    break;
                default:
                    Helpers.ShowError("Invalid selection!");
                    Console.ReadLine();
                    break;
            }
        }
    }

    private static void InstructorPage(User instructor)
    {
        while (true)
        {
            Dashboard.ShowDashboard(instructor.FullName!);

            Console.Write("\x1b[36m\x1b[1m  Choose: \x1b[0m");
            string choice = Console.ReadLine() ?? " ";

            switch (choice)
                    {
                        case "1":
                            reviewController.DisplayReviewsByInstructorId(instructor.ID);
                            break;
                        case "2":
                            CourseManage(instructor.ID);
                            break;
                        case "0":
                            return;
                        default:
                            Helpers.ShowError("Invalid selection!");
                            break;
                    }
                    Console.ReadLine();
        }
    }

    private static void CourseManage(int instructorId)
    {
        while (true)
        {
            CoursesMenu.CourseManageMenu();

            Console.Write("\x1b[36m\x1b[1m  Choose: \x1b[0m");
            string choose = Console.ReadLine() ?? " ";
            switch (choose)
            {
                case "1":
                    if (courseController.CreateCourse(instructorId))
                        Helpers.ShowSuccess("Create Course Successful!");
                    break;
                case "2":
                    while (true)
                    {
                        List<Course> courses = courseController.DisplayCoursesByInstructor(instructorId);

                        Console.Write("\x1b[36m\x1b[1m  Choose Index (Enter 0 to exit): \x1b[0m");
                        string indexCourseInput = Console.ReadLine() ?? " ";
                        int indexCourse;

                            if (int.TryParse(indexCourseInput, out indexCourse))
                            {
                                if (indexCourse == 0)
                                    return;
                                if (indexCourse > courses.Count || indexCourse < 1)
                                {
                                    Helpers.ShowError("Invalid index!");
                                }
                            else 
                            {
                                Console.WriteLine("\x1b[30m\x1b[1m" + new string('━', 153) + "\x1b[0m");

                                Console.WriteLine("1. Edit course information");
                                Console.WriteLine("2. Create lesson");
                                Console.WriteLine("3. Edit lesson");
                                Console.WriteLine("0. Cannel");

                                Console.Write("Choice: ");
                                string choice = Console.ReadLine() ?? " ";
                                switch (choice)
                                {
                                    case "1":
                                        if (courseController.EditCourse(courses[indexCourse-1]))
                                            Helpers.ShowSuccess("Course edited successfully!");
                                        break;
                                    case "2":
                                        if (lessonController.CreateLesson(courses[indexCourse-1].ID))
                                            Helpers.ShowSuccess("Lesson created successfully");
                                        break;
                                    case "3":
                                        List<Lesson> lessons = lessonController.DisplayAllLessonsForCourse(courses[indexCourse-1].ID);
                                        
                                        Console.Write("\x1b[36m\x1b[1m  Choose Lesson Index: \x1b[0m");
                                        string lessonIndexInput = Console.ReadLine() ?? " ";
                                        int lessonIndex;

                                        if (int.TryParse(lessonIndexInput, out lessonIndex))
                                        {
                                            if (lessonIndex > lessons.Count || lessonIndex < 1)
                                            {
                                                Helpers.ShowError("Invalid lesson index!");
                                            } else if (lessonController.EditCourse(lessons[lessonIndex-1].ID))
                                                Helpers.ShowSuccess("Lesson edited successfully!");
                                                else Helpers.ShowError("Error!");
                                        } else Helpers.ShowError("Invalid lesson ID");
                                            
                                        break;
                                    case "0":
                                        break;
                                    default:
                                        Helpers.ShowError("Invalid selection!");
                                        break;
                                }
                            }
                        }
                        Console.ReadLine();
                    }
                case "3":
                    courseController.DisplayCoursesByInstructor(instructorId);
                    break;
                case "0":
                    return;
                default:
                    Helpers.ShowError("Invalid selection!");
                    break;
            }
            Console.ReadLine();
        }
    }
    private static void ShowFirstMenu()
    {
        string[] lines = new string[]
            {
                $"█{new string(' ', 151)}█",
                $"█                                                               \x1b[35m\x1b[1m1. Login\x1b[33m\x1b[1m                                                                                █",
                $"█{new string(' ', 151)}█",
                $"█{new string('━', 151)}█",
                $"█{new string(' ', 151)}█",
                $"█                                                               \x1b[35m\x1b[1m2. Register\x1b[33m\x1b[1m                                                                             █",
                $"█{new string(' ', 151)}█",
                $"█{new string('━', 151)}█",
                $"█{new string(' ', 151)}█",
                $"█                                                               \x1b[35m\x1b[1m3. Search Course\x1b[33m\x1b[1m                                                                        █",
                $"█{new string(' ', 151)}█",
                $"█{new string('▂', 151)}█\n\x1b[0m",
            };
        foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
    }

    private static void ShowMainMenu()
    {
        string[] lines = new string[]
            {
                $"█{new string(' ', 151)}█",
                $"█                                                               \x1b[35m\x1b[1m1. User Manage\x1b[33m\x1b[1m                                                                          █",
                $"█{new string(' ', 151)}█",
                $"█{new string('━', 151)}█",
                $"█{new string(' ', 151)}█",
                $"█                                                               \x1b[35m\x1b[1m2. Search Course\x1b[33m\x1b[1m                                                                        █",
                $"█{new string(' ', 151)}█",
                $"█{new string('━', 151)}█",
                $"█{new string(' ', 151)}█",
                $"█                                                               \x1b[35m\x1b[1m3. Go To My Learning\x1b[33m\x1b[1m                                                                    █",
                $"█{new string(' ', 151)}█",
                $"█{new string('━', 151)}█",
                $"█{new string(' ', 151)}█",
                $"█                                                               \x1b[35m\x1b[1m4. Instructor Page\x1b[33m\x1b[1m                                                                      █",
                $"█{new string(' ', 151)}█",
                $"█{new string('▂', 151)}█\n\x1b[0m",
            };
        foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
    }
}