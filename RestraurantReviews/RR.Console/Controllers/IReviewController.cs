using RR.Console.Views;
using RR.ViewModels;

namespace RR.Console.Controllers
{
    public interface IReviewController
    {
        ActionResult AddReview(AddReviewViewModel viewModel);
        ActionResult InputAddReview();
        ActionResult RestaurantReviews(string restaurantsName);
        ActionResult InputUpdateReview();
        ActionResult UpdateReview(UpdateReviewViewModel viewModel);
        ActionResult InputDeleteReview();
        ActionResult DeleteReview(int reviewId);
    }
}
