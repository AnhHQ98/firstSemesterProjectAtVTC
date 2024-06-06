using CoursesSystem.Utils;
using CoursesSystem.Controllers;
using CoursesSystem.Models;

namespace CoursesSystem.Views.Courses
{
    public class Create
    {
        public string? Title { get; private set; }
        public string? Description { get; private set; }
        public int CategoryID { get; private set; }
        public double Price { get; private set; }
        public string? Level { get; private set; }
        public void CreateCourse()
        {
            CategoryController categoryController = new CategoryController();
            Console.Clear();
            Helpers.Logo(" Create Course  ");

            Console.Write("\x1b[34m\x1b[1m❀  Enter Title: \x1b[0m");
            string? title = Console.ReadLine()?.Trim();

            while (string.IsNullOrEmpty(title))
            {
                Console.WriteLine("\x1b[31mTitle cannot be empty. Please enter a title.\x1b[0m");
                Console.Write("\x1b[34m\x1b[1m❀  Enter Title: \x1b[0m");
                title = Console.ReadLine()?.Trim();
            }
            Title = title;

            Console.Write("\x1b[34m\x1b[1m❀  Enter Description: \x1b[0m");
            string? description = Console.ReadLine()?.Trim();

            while (string.IsNullOrEmpty(description))
            {
                Console.WriteLine("\x1b[31mDescription cannot be empty. Please enter a description.\x1b[0m");
                Console.Write("\x1b[34m\x1b[1m❀  Enter Description: \x1b[0m");
                description = Console.ReadLine()?.Trim();
            }
            Description = description;

            List<Category> categories = categoryController.DisplayCategories();

            int categoryIndex;
            string? categoryIndexInput;

            while (true)
            {
                Console.Write($"\x1b[34m\x1b[1m❀  Enter Category Index: \x1b[0m");
                categoryIndexInput = Console.ReadLine();

                if (int.TryParse(categoryIndexInput, out categoryIndex) && categoryIndex > 0 && categoryIndex <= categories.Count)
                {
                    break;
                } else {
                    Console.WriteLine("\x1b[31m\x1b[1m Invalid!\x1b[0m");
                }
            }
            CategoryID = categories[categoryIndex-1].ID;

            Console.Write("\x1b[34m\x1b[1m❀  Enter Price: \x1b[0m");
            string? priceInput = Console.ReadLine();
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
            Price = price;

            Console.Write("\x1b[34m\x1b[1m❀  Enter Level ('Beginner', 'Intermediate', 'Advanced'): \x1b[0m");
            Level = Console.ReadLine()?.Trim();

            while (!new[] { "Beginner", "Intermediate", "Advanced" }.Contains(Level, StringComparer.OrdinalIgnoreCase))
            {
                Console.WriteLine("\x1b[31mInvalid input. Please enter 'Beginner', 'Intermediate', or 'Advanced'.\x1b[0m");
                Console.Write("\x1b[34m\x1b[1m❀  Enter Level ('Beginner', 'Intermediate', 'Advanced'): \x1b[0m");
                Level = Console.ReadLine()?.Trim();
            }
        }
    }
}