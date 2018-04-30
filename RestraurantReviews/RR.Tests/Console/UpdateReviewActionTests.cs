using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RR.Console;
using RR.Console.Actions;
using RR.Console.Controllers;
using RR.ViewModels;

namespace RR.Tests.Console
{
    [TestClass]
    public class UpdateReviewActionTests
    {
        private readonly Mock<IRestaurantController> _restaurantController;
        private readonly Mock<IInputOutput> _inputOutput;
        private readonly Mock<IReviewController> _reviewController;

        public UpdateReviewActionTests()
        {
            _restaurantController = new Mock<IRestaurantController>();
            _inputOutput = new Mock<IInputOutput>();
            _reviewController = new Mock<IReviewController>();

            _inputOutput.Setup(x => x.ReadString());
            _inputOutput.Setup(x => x.ReadInteger());
            _inputOutput.Setup(x => x.ReadDouble());
            _restaurantController.Setup(x => x.AllRestaurants().Render());
            _reviewController.Setup(x => x.RestaurantReviews(It.IsAny<string>()).Render());
            _reviewController.Setup(x => x.UpdateReview(It.IsAny<UpdateReviewViewModel>()).Render());
            _reviewController.Setup(x => x.InputUpdateReview().Render());
        }

        [TestMethod]
        public void Execute_OnCall_RendersAllRestaurants()
        {
            var action = new UpdateReviewAction(_restaurantController.Object, _reviewController.Object, _inputOutput.Object);

            action.Execute();

            _restaurantController.Verify(x => x.AllRestaurants().Render(), Times.AtLeastOnce);
        }

        [TestMethod]
        public void Execute_OnCall_CallsRestaurantReviews()
        {
            var action = new UpdateReviewAction(_restaurantController.Object, _reviewController.Object, _inputOutput.Object);

            action.Execute();

            _reviewController.Verify(x => x.RestaurantReviews(It.IsAny<string>()), Times.AtLeastOnce);
        }

        [TestMethod]
        public void Execute_OnCall_CallInputUpdateReview()
        {
            var action = new UpdateReviewAction(_restaurantController.Object, _reviewController.Object, _inputOutput.Object);

            action.Execute();

            _reviewController.Verify(x => x.InputUpdateReview().Render(), Times.AtLeastOnce);
        }

        [TestMethod]
        public void Execute_OnCall_RendersRestaurantReviews()
        {
            var action = new UpdateReviewAction(_restaurantController.Object, _reviewController.Object, _inputOutput.Object);

            action.Execute();

            _reviewController.Verify(x => x.RestaurantReviews(It.IsAny<string>()).Render(), Times.AtLeastOnce);
        }

        [TestMethod]
        public void Execute_OnCall_CallsUpdateReview()
        {
            var action = new UpdateReviewAction(_restaurantController.Object, _reviewController.Object, _inputOutput.Object);

            action.Execute();

            _reviewController.Verify(x => x.UpdateReview(It.IsAny<UpdateReviewViewModel>()), Times.AtLeastOnce);
        }

        [TestMethod]
        public void Execute_OnCall_RendersUpdateReview()
        {
            var action = new UpdateReviewAction(_restaurantController.Object, _reviewController.Object, _inputOutput.Object);

            action.Execute();

            _reviewController.Verify(x => x.UpdateReview(It.IsAny<UpdateReviewViewModel>()).Render(), Times.AtLeastOnce);
        }
    }
}
