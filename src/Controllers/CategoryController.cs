using CoursesSystem.Models;
using CoursesSystem.Services;
using CoursesSystem.Views.Categories;

namespace CoursesSystem.Controllers
{
    public class CategoryController
    {
        private readonly CategoryService categoryService = new CategoryService();
        public List<Category> DisplayCategories()
        {
            List list = new List();
            List<Category> categories = categoryService.GetAllCategory();
            list.DisplayAllCategories(categories);


            return categories;
        }
    public Category? GetCategory(int categoryId)
    {
        return categoryService.GetCategory(categoryId);
    }
    }
}