using CoursesSystem.Utils;

namespace CoursesSystem.Views.Payments
{
    public class Processor
    {
        public string? Choice { get; private set; }
        public void PaymentInfo(double amount)
        {
            string cardNumber, expiryDate, cvv;

            Console.Write("\n\x1b[34m\x1b[1m❀  Card number: \x1b[0m");
            cardNumber = Console.ReadLine() ?? "";

            while (!Helpers.ValidateCardNumber(cardNumber))
            {
                Helpers.ShowError("Card code format is incorrect!");
                Console.Write("\n\x1b[34m\x1b[1m❀  Card number: \x1b[0m");
                cardNumber = Console.ReadLine() ?? "";
            }

            Console.Write("\x1b[34m\x1b[1m❀  Expiry date (MM/YY): \x1b[0m");
            expiryDate = Console.ReadLine() ?? "";
            while (!Helpers.ValidateExpiryDate(expiryDate))
            {
                Helpers.ShowError("Date on card is invalid!");
                Console.Write("\x1b[34m\x1b[1m❀  Expiry date (MM/YY): \x1b[0m");
                expiryDate = Console.ReadLine() ?? "";
            }

            Console.Write("\x1b[34m\x1b[1m❀  CVV: \x1b[0m");
            cvv = Console.ReadLine() ?? "";
            while (!Helpers.ValidateCvv(cvv))
            {
                Helpers.ShowError("CVV is invalid!");
                Console.Write("\x1b[34m\x1b[1m❀  CVV: \x1b[0m");
                cvv = Console.ReadLine() ?? "";
            }

            Console.WriteLine($"\x1b[34m\x1b[1m❀  Amount: {amount:C} VND \x1b[0m");

            Console.WriteLine($"\n\x1b[34m\x1b[1m   1. Proceed\n   2. Cancel\x1b[0m");

            Choice = Console.ReadLine();
        }
    }
}