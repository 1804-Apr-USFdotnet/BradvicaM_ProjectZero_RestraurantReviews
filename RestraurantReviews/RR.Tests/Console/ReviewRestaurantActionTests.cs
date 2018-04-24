using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RR.Console;
using RR.Console.Actions;
using RR.Console.Controllers;
using RR.ViewModels;

namespace RR.Tests.Console
{
    [TestClass]
    public class ReviewRestaurantActionTests
    {
        private readonly Mock<IReviewController> _controller;
        private readonly Mock<IInputOutput> _inputOutput;

        public ReviewRestaurantActionTests()
        {
            _controller = new Mock<IReviewController>();
            _inputOutput = new Mock<IInputOutput>();

            _controller.Setup(x => x.InputAddReview().Render());
            _controller.Setup(x => x.AddReview(It.IsAny<AddReviewViewModel>()).Render());
        }

        [TestMethod]
        public void Execute_OnCall_ExecutesAddReview()
        {
            var action = new ReviewRestaurantAction(_controller.Object, _inputOutput.Object);

            action.Execute();

            _controller.Verify(x => x.AddReview(It.IsAny<AddReviewViewModel>()), Times.AtLeastOnce);
        }

        [TestMethod]
        public void Execute_OnCall_RendersFirstView()
        {
            var action = new ReviewRestaurantAction(_controller.Object, _inputOutput.Object);

            action.Execute();

            _controller.Verify(x => x.InputAddReview().Render(), Times.AtLeastOnce);
        }

        [TestMethod]
        public void Execute_OnCall_RendersSecondView()
        {
            var action = new ReviewRestaurantAction(_controller.Object, _inputOutput.Object);

            action.Execute();

            _controller.Verify(x => x.AddReview(It.IsAny<AddReviewViewModel>()).Render(), Times.AtLeastOnce);
        }
    }
}
