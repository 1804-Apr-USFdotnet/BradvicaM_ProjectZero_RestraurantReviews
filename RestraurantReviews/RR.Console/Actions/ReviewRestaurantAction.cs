using RR.Console.Controllers;
using RR.ViewModels;

namespace RR.Console.Actions
{
    public class ReviewRestaurantAction : IApplicationAction
    {
        private readonly ReviewController _reviewController;
        private readonly IInputOutput _inputOutput;

        public ReviewRestaurantAction(ReviewController reviewController, IInputOutput inputOutput)
        {
            _reviewController = reviewController;
            _inputOutput = inputOutput;
        }

        public void Execute()
        {
            _reviewController.InputAddReview().Render();

            var restaurant = _inputOutput.ReadString();
            var name = _inputOutput.ReadString();
            var rating = _inputOutput.ReadDouble();
            var comment = _inputOutput.ReadString();

            var viewModel = new AddReviewViewModel
            {
                Comment = comment,
                Restaurant = restaurant,
                Rating = rating,
                ReviewerName = name
            };

            _reviewController.AddReview(viewModel).Render();
        }
    }
}
