using CoursesSystem.Controllers;
using CoursesSystem.Models;
using CoursesSystem.Utils;

namespace CoursesSystem.Views.Payments
{
    public class History
    {
        public void DisplayPaymentHistory(IEnumerable<Payment> payments)
        {
            CourseController courseController = new CourseController();
            
            Console.Clear();
            Helpers.Logo(" Payment History");
            Console.WriteLine("\x1b[30m\x1b[1m" + new string('━', 153) + "\x1b[0m");
            Console.WriteLine($"\x1b[1m▏{"Course Title",-82} ▏{"Amount",-19} ▏{"Payment Date",-24} ▏{"Payment Status",-20}▕\x1b[0m");
            Console.WriteLine("\x1b[30m\x1b[1m" + new string('━', 153) + "\x1b[0m");

            foreach (var payment in payments)
            {
                Course? course = courseController.GetCourseByID(payment.CourseID);

                Console.WriteLine($"▏{course?.Title,-82} ▏{payment.Amount,-19:C} ▏{payment.PaymentDate,-24} ▏{payment.Status,-20}▕");
                Console.WriteLine("\x1b[30m\x1b[1m" + new string('━', 153) + "\x1b[0m");
            }

            if (!payments.GetEnumerator().MoveNext())
            {
                Console.WriteLine("No payments found.");
            }

            Console.WriteLine();
        }
    }
}