using CoursesSystem.Views.Reviews;
using CoursesSystem.Services;
using CoursesSystem.Models;

namespace CoursesSystem.Controllers
{
    public class ReviewController
    {
        private readonly ReviewService reviewService = new ReviewService();
        public bool CreateReview(int userId, int courseId)
        {
            try{
            Create create = new Create();
            create.CreateReview();

            Review review = new Review {
                Rating = create.Rating,
                Comment = create.Comment,
                DatePosted = create.DatePosted,
                UserID = userId,
                CourseID = courseId
            };

            reviewService.CreateReview(review);
            return true;
            } catch {
                return false;
            }
        }
        public void DisplayReviewsByCourseId(int courseId)
        {
            List list = new List();
            list.ShowReviews(reviewService.GetReviewsByCourseID(courseId));
        }
        public void DisplayReviewsByInstructorId(int instructorId)
        {
            List list = new List();
            list.ShowReviews(reviewService.GetReviewsByInstructorID(instructorId));
        }
        public bool CheckCourseEvaluation(int courseId, int userId)
        {
            return reviewService.IsCourseEvaluatedByUser(courseId, userId);
        }
    }
}