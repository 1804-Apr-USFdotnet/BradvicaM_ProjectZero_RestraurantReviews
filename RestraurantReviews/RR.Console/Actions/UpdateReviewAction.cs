using RR.Console.Controllers;
using RR.ViewModels;

namespace RR.Console.Actions
{
    public class UpdateReviewAction : IApplicationAction
    {
        private readonly IRestaurantController _restaurantController;
        private readonly IReviewController _reviewController;
        private readonly IInputOutput _inputOutput;

        public UpdateReviewAction(IRestaurantController restaurantController, IReviewController reviewController, IInputOutput inputOutput)
        {
            _restaurantController = restaurantController;
            _reviewController = reviewController;
            _inputOutput = inputOutput;
        }

        public void Execute()
        {
            _restaurantController.AllRestaurants().Render();

            var restaurantForReviews = _inputOutput.ReadString();

            _reviewController.RestaurantReviews(restaurantForReviews).Render();

            _reviewController.InputUpdateReview().Render();

            var id = _inputOutput.ReadInteger();
            var name = _inputOutput.ReadString();
            var rating = _inputOutput.ReadDouble();
            var comment = _inputOutput.ReadString();

            var viewModel = new UpdateReviewViewModel
            {
                Rating = rating,
                ReviewerName = name,
                Comment = comment, 
                ReviewIdentification = id
            };

            _reviewController.UpdateReview(viewModel).Render();
        }
    }
}
