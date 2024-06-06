using CoursesSystem.Models;
using CoursesSystem.src.DataAccess;

namespace CoursesSystem.Services
{
    public class CategoryService
    {
        private readonly CategoryDAL categoryDAL = new CategoryDAL();
        public List<Category> GetAllCategory()
        {
           return categoryDAL.GetAll();
        }
        public Category? GetCategory(int categoryID)
        {
            return categoryDAL.GetCategory(categoryID);
        }
    }
}