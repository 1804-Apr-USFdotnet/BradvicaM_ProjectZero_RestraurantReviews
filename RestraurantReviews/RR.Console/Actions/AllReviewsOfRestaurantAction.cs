using RR.Console.Controllers;

namespace RR.Console.Actions
{
    public class AllReviewsOfRestaurantAction : IApplicationAction
    {
        private readonly IRestaurantController _restaurantController;
        private readonly IReviewController _reviewController;
        private readonly IInputOutput _inputOutput;

        public AllReviewsOfRestaurantAction(IRestaurantController restaurantController, IReviewController reviewController, IInputOutput inputOutput)
        {
            _restaurantController = restaurantController;
            _reviewController = reviewController;
            _inputOutput = inputOutput;
        }

        public void Execute()
        {
            _restaurantController.AllRestaurants().Render();

            var input = _inputOutput.ReadString();

            _reviewController.RestaurantReviews(input).Render();
        }
    }
}
