using RR.Console.Controllers;

namespace RR.Console.Actions
{
    public class DeleteReviewAction : IApplicationAction
    {
        private readonly IReviewController _reviewController;
        private readonly IRestaurantController _restaurantController;
        private readonly IInputOutput _inputOutput;

        public DeleteReviewAction(IReviewController reviewController, IInputOutput inputOutput, IRestaurantController restaurantController)
        {
            _reviewController = reviewController;
            _inputOutput = inputOutput;
            _restaurantController = restaurantController;
        }

        public void Execute()
        {
            _restaurantController.AllRestaurants().Render();

            var restaurantForReviews = _inputOutput.ReadString();

            _reviewController.RestaurantReviews(restaurantForReviews).Render();

            _reviewController.InputDeleteReview().Render();

            var reviewForDelete = _inputOutput.ReadInteger();

            _reviewController.DeleteReview(reviewForDelete).Render();
        }
    }
}
