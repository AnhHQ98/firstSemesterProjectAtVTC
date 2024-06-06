using CoursesSystem.Models;
using CoursesSystem.Utils;

namespace CoursesSystem.Views.Categories
{
    public class List
    {
        public void DisplayAllCategories(List<Category> categories)
        {
            if (categories == null)
            {
                Helpers.ShowError("No categories to display.");
                return;
            }

            Console.WriteLine("\x1b[92m\x1b[1m\x1b[5m" + new string(' ', 65) + " List of all categories\x1b[0m");
            Console.WriteLine("\x1b[30m\x1b[1m" + new string('━', 153) + "\x1b[0m");
            Console.WriteLine($"\x1b[1m▏{"ID",-13} ▏{"Name",-32} ▏{"Description",-102}▕\x1b[0m");
            Console.WriteLine("\x1b[30m\x1b[1m" + new string('━', 153) + "\x1b[0m");

            foreach (var category in categories)
            {
                Console.WriteLine($"▏{category.ID,-13} ▏{category.Name,-32} ▏{category.Description,-102}▕");
                Console.WriteLine("\x1b[30m\x1b[1m" + new string('━', 153) + "\x1b[0m");
            }
        }
    }
}