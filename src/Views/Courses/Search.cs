using CoursesSystem.Controllers;
using CoursesSystem.Models;
using CoursesSystem.Utils;

namespace CoursesSystem.Views.Courses
{
    public class Search
    {
        private string? keywords;
        private string? filterChoice;
        private double? minRating = null;
        private bool? isFree = null;
        private int categoryId;

        public void ShowSearchCourse()
        {
            Console.Clear();
            Helpers.Logo("  SEARCH COURSE ");

            CategoryController categoryController = new CategoryController();
            Console.Write("\n\x1b[34m\x1b[1m⌕  Search for anything: \x1b[0m");
            keywords = Console.ReadLine();

            Console.Write("\n\x1b[34m\x1b[1m☉  Apply filters? (Y/N): \x1b[0m");
            filterChoice = Console.ReadLine();

            if (string.Equals(filterChoice, "Y", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("\n1. Rating: 4.5 & up");
                Console.WriteLine("2. Rating: 4.0 & up");
                Console.WriteLine("3. Rating: 3.5 & up");
                Console.WriteLine("4. Rating: 3.0 & up");
                Console.Write("Select Rating Filter (leave blank to skip): ");
                string? ratingChoice = Console.ReadLine();

                minRating = ratingChoice switch
                {
                    "1" => 4.5,
                    "2" => 4.0,
                    "3" => 3.5,
                    "4" => 3.0,
                    _ => null, 
                };

                Console.Write("\nSelect Course Type (1 for Paid, 2 for Free, leave blank to skip): ");
                string? typeChoice = Console.ReadLine();

                isFree = typeChoice switch
                {
                    "1" => false,
                    "2" => true,
                    _ => null,
                };

                List<Category> categories = categoryController.DisplayCategories();
                Console.Write("\nEnter Category Index (leave blank to skip): ");

                string? categoryIndexInput = Console.ReadLine()?.Trim();
                int categoryIndex;
                int categoryIndexMax = categories.Count;

                while (!string.IsNullOrEmpty(categoryIndexInput))
                {
                    if (int.TryParse(categoryIndexInput, out categoryIndex) && categoryIndex >= 1 && categoryIndex <= categoryIndexMax)
                    {
                        categoryId = categoryIndex;
                        break;
                    }
                    else
                    {
                        Helpers.ShowError("Invalid input. Please enter a valid category index or leave blank to skip!");
                        Console.Write("\nEnter Category Index (leave blank to skip): ");
                        categoryIndexInput = Console.ReadLine()?.Trim();
                    }
                }
            }
        }
        public string? Keywords { get => keywords;}
        public double? MinRating { get => minRating;  }
        public bool? IsFree { get => isFree; }
        public int CategoryID { get => categoryId; }
    }
}