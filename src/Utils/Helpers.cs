using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mail;

namespace CoursesSystem.Utils
{
    public class Helpers
    {
        private const string fromEmail = "quanvvi369@gmail.com"; 
        private const string appPassword = "hyksiyndhxqvxzld";
        public static void ShowError(string errorMessage)
        {
            Console.WriteLine("\x1b[31m\x1b[1m" + errorMessage + "\x1b[0m");
        }
        public static void ShowSuccess(string successMessage)
        {
            Console.WriteLine("\x1b[32m\x1b[1m" + successMessage + "\x1b[0m");
        }
        public static bool IsValidEmail(string email)
        {
            string emailPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

            return Regex.IsMatch(email, emailPattern);
        }
        public static bool IsValidPhoneNumber(string phone)
        {
            string phonePattern = @"^(0|84|\+84)\d{9}$";

            return Regex.IsMatch(phone, phonePattern);
        }
        public static string InputPassword()
        {
            string password = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true); 

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                    {
                        password = password.Substring(0, (password.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            }
            while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();
            return password;
        }

        public static bool SendEmail(string toEmail, string subject, string body)
        {
            try
            {
                using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(fromEmail, appPassword);

                    using (var message = new MailMessage())
                    {
                        message.From = new MailAddress(fromEmail);
                        message.Subject = subject;
                        message.Body = body;
                        message.IsBodyHtml = true;
                        message.To.Add(new MailAddress(toEmail));

                        smtpClient.Send(message);
                    }
                }
                
                return true;
            }
            catch (SmtpException ex)
            {
                Console.WriteLine("SMTP error occurred: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
                }
                return false;
            }
        }

        public static bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                ShowError("Not be empty");
                return false;
            }
            if (password.Length < 8)
            {
                ShowError("Password must have a minimum length of 8 characters");
                return false;
            }
            if (!Regex.IsMatch(password, "[a-z]"))
            {
                ShowError("Password must have at least 1 letter");
                return false;
            }
            if (!Regex.IsMatch(password, "[0-9]"))
            {
                ShowError("Password must have at least 1 digit");
                return false;
            }
            return true;
        }

        public static bool ValidateCardNumber(string cardNumber)
        {
            var regex = new Regex(@"^(?:4[0-9]{12}(?:[0-9]{3})?          # Visa
                                    |  (?:5[1-5][0-9]{2}                # MasterCard
                                    |  222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}
                                    |  3[47][0-9]{13}                   # American Express
                                    |  3(?:0[0-5]|[68][0-9])[0-9]{11}    # Diners Club
                                    |  6(?:011|5[0-9]{2})[0-9]{12}       # Discover
                                    |  (?:2131|1800|35\d{3})\d{11}       # JCB
                                    )$", RegexOptions.IgnorePatternWhitespace);
            return regex.IsMatch(cardNumber);
        }

        public static bool ValidateExpiryDate(string expiryDate)
        {
            if (DateTime.TryParseExact(expiryDate, "MM/yy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime expDate))
            {
                return expDate > DateTime.Now;
            }
            return false;
        }

        public static bool ValidateCvv(string cvv)
        {
            return Regex.IsMatch(cvv, @"^\d{3,4}$");
        }
        public static void Logo(string pageName)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(new string('▂', 153));

            string[] lines = new string[]
            {
                @"█            _____    ___     _   _       _   ___     _   ______        _____     _____     _      _    ______     _____    ______     _____            █",
                @"█           / ___ \  |   \   | | | |     | | |   \   | | |  ____|     /  ___ \   / ___ \   | |    | |  / ____ \   /  __ \  |  ____|   /  __ \           █",
                @"█          | |   | | | |\ \  | | | |     | | | |\ \  | | | |____     |  /       | |   | |  | |    | | | /____| |   \ \ \_\ | |____     \ \ \_\          █",
                @"█          | |   | | | | \ \ | | | |     | | | | \ \ | | |  ____|    | |     _  | |   | |  | |    | | |  ___  /  __  \ \   |  ____|  __  \ \            █",
                @"█          | |___| | | |  \ \| | | |____ | | | |  \ \| | | |____     |  \___/ | | |___| |  | |    | | | |   \ \  \ \ _\ \  | |____   \ \ _\ \           █",
                @"█           \_____/  |_|   \___| |______||_| |_|   \___| |______|     \______/   \_____/    \_\__/_/  |_|    \_\  \_____/  |______|   \_____/           █",
                @"█                                                                                                                                                       █",
                $"█                                                                \x1b[1m{pageName}                                                                       █"
            };

            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine($"█{new string('▂', 151)}█");

        }
    }
}
