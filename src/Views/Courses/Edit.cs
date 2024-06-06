using CoursesSystem.Models;
using CoursesSystem.Utils;

namespace CoursesSystem.Views.Courses
{
    public class Edit
    {
        public void EditCourse(Course course)
        {
            Console.Clear();
            Helpers.Logo("  Edit Course   ");

            Console.Write($"\x1b[34m\x1b[1m❀  Enter Course Title ({course.Title}): \x1b[0m");
            string? titleInput = Console.ReadLine()?.Trim();
            course.Title = string.IsNullOrEmpty(titleInput) ? course.Title : titleInput;

            Console.Write($"\x1b[34m\x1b[1m❀  Enter Course Description ({course.Description}): \x1b[0m");
            string? descriptionInput = Console.ReadLine()?.Trim();
            course.Description = string.IsNullOrEmpty(descriptionInput) ? course.Description : descriptionInput;

            Console.Write($"\x1b[34m\x1b[1m❀  Enter Course Price ({course.Price}): \x1b[0m");
            string? priceInput = Console.ReadLine()?.Trim();

            if (!string.IsNullOrEmpty(priceInput))
            {
                int price;

                while (!int.TryParse(priceInput, out price) || price < 0)
                {
                    if (!int.TryParse(priceInput, out price))
                    {
                        Console.WriteLine("\x1b[31m\x1b[1m Invalid input: Not a valid integer.\x1b[0m");
                    }
                    else if (price < 0)
                    {
                        Console.WriteLine("\x1b[31m\x1b[1m Invalid input: Price cannot be negative.\x1b[0m");
                    }

                    Console.Write("\x1b[34m\x1b[1m❀  Enter Price: \x1b[0m");
                    priceInput = Console.ReadLine();
                }
                course.Price = price;
            }

            Console.Write($"\x1b[34m\x1b[1m❀  Enter Course Level ({course.Level}): \x1b[0m");
            string? levelInput = Console.ReadLine()?.Trim();

            if (!string.IsNullOrEmpty(levelInput))
            {
                while (levelInput != "Beginner" && levelInput != "Intermediate" && levelInput != "Advanced")
                {
                    Console.WriteLine("\x1b[31mInvalid input. Please enter 'Beginner', 'Intermediate', or 'Advanced'.\x1b[0m");
                    Console.Write("\x1b[34m\x1b[1m❀  Enter Level ('Beginner', 'Intermediate', 'Advanced'): \x1b[0m");
                    levelInput = Console.ReadLine()?.Trim();
                }
                course.Level = levelInput; 
            }
        }
    }
}