using CoursesSystem.DataAccess;
using CoursesSystem.Models;

namespace CoursesSystem.Services
{
    public class ReviewService
    {
        private readonly ReviewDAL reviewDAL = new ReviewDAL();
        public void CreateReview(Review review)
        {
            reviewDAL!.Add(review);
        }
        public List<Review> GetReviewsByCourseID(int courseId)
        {
            return reviewDAL!.GetList(courseId);
        }
        public List<Review> GetReviewsByInstructorID(int instructorId)
        {
            return reviewDAL!.GetAllReviewsForInstructor(instructorId);
        }
        public bool IsCourseEvaluatedByUser(int courseId, int userId)
        {
            List<Review> reviews = GetReviewsByCourseID(courseId);

            return reviews.Any(r => r.UserID == userId);
        }
    }
}