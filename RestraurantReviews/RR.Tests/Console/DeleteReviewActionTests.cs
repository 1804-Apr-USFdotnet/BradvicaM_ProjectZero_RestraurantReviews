using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RR.Console;
using RR.Console.Actions;
using RR.Console.Controllers;

namespace RR.Tests.Console
{
    [TestClass]
    public class DeleteReviewActionTests
    {
        private readonly Mock<IReviewController> _reviewController;
        private readonly Mock<IRestaurantController> _restaurantController;
        private readonly Mock<IInputOutput> _inputOutput;

        public DeleteReviewActionTests()
        {
            _reviewController = new Mock<IReviewController>();
            _restaurantController = new Mock<IRestaurantController>();
            _inputOutput = new Mock<IInputOutput>();

            _restaurantController.Setup(x => x.AllRestaurants().Render());
            _inputOutput.Setup(x => x.ReadString());
            _reviewController.Setup(x => x.RestaurantReviews(It.IsAny<string>()).Render());
            _reviewController.Setup(x => x.InputDeleteReview().Render());
            _reviewController.Setup(x => x.DeleteReview(It.IsAny<int>()).Render());
        }

        [TestMethod]
        public void Execute_OnCall_RendersAllRestaurants()
        {
            var action = new DeleteReviewAction(_reviewController.Object, _inputOutput.Object, _restaurantController.Object);

            action.Execute();

            _restaurantController.Verify(x => x.AllRestaurants().Render(), Times.AtLeastOnce);
        }

        [TestMethod]
        public void Execute_OnCall_CallRestaurantReviews()
        {
            var action = new DeleteReviewAction(_reviewController.Object, _inputOutput.Object, _restaurantController.Object);

            action.Execute();

            _reviewController.Verify(x => x.RestaurantReviews(It.IsAny<string>()), Times.AtLeastOnce);
        }

        [TestMethod]
        public void Execute_OnCall_RendersRestaurantReviews()
        {
            var action = new DeleteReviewAction(_reviewController.Object, _inputOutput.Object, _restaurantController.Object);

            action.Execute();

            _reviewController.Verify(x => x.RestaurantReviews(It.IsAny<string>()).Render(), Times.AtLeastOnce);
        }

        [TestMethod]
        public void Execute_OnCall_RendersInputDeleteReview()
        {
            var action = new DeleteReviewAction(_reviewController.Object, _inputOutput.Object, _restaurantController.Object);

            action.Execute();

            _reviewController.Verify(x => x.InputDeleteReview().Render(), Times.AtLeastOnce);
        }

        [TestMethod]
        public void Execute_OnCall_CallsDeleteReview()
        {
            var action = new DeleteReviewAction(_reviewController.Object, _inputOutput.Object, _restaurantController.Object);

            action.Execute();

            _reviewController.Verify(x => x.DeleteReview(It.IsAny<int>()), Times.AtLeastOnce);
        }

        [TestMethod]
        public void Execute_OnCall_RendersDeleteReview()
        {
            var action = new DeleteReviewAction(_reviewController.Object, _inputOutput.Object, _restaurantController.Object);

            action.Execute();

            _reviewController.Verify(x => x.DeleteReview(It.IsAny<int>()).Render(), Times.AtLeastOnce);
        }
    }
}
