using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RR.Console;
using RR.Console.Actions;
using RR.Console.Controllers;

namespace RR.Tests.Console
{
    [TestClass]
    public class AllReviewsOfRestaurantActionTests
    {
        private readonly Mock<IInputOutput> _inputOutput;
        private readonly Mock<IRestaurantController> _restaurantMock;
        private readonly Mock<IReviewController> _reviewMock;

        public AllReviewsOfRestaurantActionTests()
        {
            _inputOutput = new Mock<IInputOutput>();
            _restaurantMock = new Mock<IRestaurantController>();
            _reviewMock = new Mock<IReviewController>();

            _restaurantMock.Setup(x => x.AllRestaurants().Render());
            _reviewMock.Setup(x => x.RestaurantReviews(It.IsAny<string>()));
            _reviewMock.Setup(x => x.RestaurantReviews(It.IsAny<string>()).Render());
        }

        [TestMethod]
        public void Execute_OnCall_RendersFirstView()
        {
            var action = new AllReviewsOfRestaurantAction(_restaurantMock.Object, _reviewMock.Object, _inputOutput.Object);

            action.Execute();

            _restaurantMock.Verify(x => x.AllRestaurants().Render(), Times.AtLeastOnce);
        }

        [TestMethod]
        public void Execute_OnCall_CallCorrectMethod()
        {
            var action = new AllReviewsOfRestaurantAction(_restaurantMock.Object, _reviewMock.Object, _inputOutput.Object);

            action.Execute();

            _reviewMock.Verify(x => x.RestaurantReviews(It.IsAny<string>()), Times.AtLeastOnce);
        }

        [TestMethod]
        public void Executed_OnCall_RendersSecondView()
        {
            var action = new AllReviewsOfRestaurantAction(_restaurantMock.Object, _reviewMock.Object, _inputOutput.Object);

            action.Execute();

            _reviewMock.Verify(x => x.RestaurantReviews(It.IsAny<string>()).Render(), Times.AtLeastOnce);
        }
    }
}
