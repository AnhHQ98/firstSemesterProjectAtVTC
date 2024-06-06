using CoursesSystem.DataAccess;
using CoursesSystem.Models;

namespace CoursesSystem.Services
{
    public class PaymentService
    {
        private readonly PaymentDAL paymentDAL = new PaymentDAL();
        public List<Payment> GetPayments(int studentId)
        {
            return paymentDAL.GetList(studentId);
        }

        public bool HandlePayment(Payment payment)
        {
            try
            {    
                paymentDAL.Add(payment); // add a payment success => auto add a enrollment

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return false;
            }
        }
    }
}