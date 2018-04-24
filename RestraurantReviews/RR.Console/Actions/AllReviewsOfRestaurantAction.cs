using RR.Console.Controllers;

namespace RR.Console.Actions
{
    internal class AllReviewsOfRestaurantAction : IApplicationAction
    {
        private readonly RestaurantController _restaurantController;
        private readonly ReviewController _reviewController;
        private readonly IInputOutput _inputOutput;

        public void Execute()
        {
            _restaurantController.InputRestaurantName().Render();

            var input = _inputOutput.ReadString();

            _reviewController.RestaurantReviews(input).Render();
        }
    }
}
