using CoursesSystem.Views.Payments;
using CoursesSystem.Services;
using CoursesSystem.Models;

namespace CoursesSystem.Controllers
{
    public class PaymentController
    {
        private readonly PaymentService paymentService = new PaymentService();
        public void DisplayPaymentHistory(int studentId)
        {
            History historyView = new History();
            historyView.DisplayPaymentHistory(paymentService.GetPayments(studentId));
        }
        public bool MakePayment(Course course, int userId)
        {
            Processor processor = new Processor();
            processor.PaymentInfo(course.Price);

            Payment payment = new Payment {
                UserID = userId,
                CourseID = course.ID,
                Amount = course.Price,
                PaymentDate = DateTime.Now,
                Status = "Incomplete"
            };

            if (processor.Choice == "1")
            {
                payment.Status = "Completed";
                paymentService.HandlePayment(payment);
                return true;
            }

            paymentService.HandlePayment(payment);
            return false;
        }
    }
}