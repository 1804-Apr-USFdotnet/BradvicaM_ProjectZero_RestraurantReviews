using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RR.Console;
using RR.Console.Actions;
using RR.Console.Controllers;

namespace RR.Tests.Console
{
    [TestClass]
    public class ViewRestaurantDetailsActionTests
    {
        private readonly Mock<IRestaurantController> _controller;
        private readonly Mock<IInputOutput> _inputOutput;

        public ViewRestaurantDetailsActionTests()
        {
            _controller = new Mock<IRestaurantController>();
            _inputOutput = new Mock<IInputOutput>();

            _controller.Setup(x => x.AllRestaurants().Render());
            _controller.Setup(x => x.RestaurantDetails(It.IsAny<string>()).Render());
        }

        [TestMethod]
        public void Execute_OnCall_RendersFirstView()
        {
            var action = new ViewRestaurantDetailsAction(_controller.Object, _inputOutput.Object);

            action.Execute();

            _controller.Verify(x => x.AllRestaurants().Render(), Times.AtLeastOnce);
        }

        [TestMethod]
        public void Execute_OnCall_CallCorrectMethod()
        {
            var action = new ViewRestaurantDetailsAction(_controller.Object, _inputOutput.Object);

            action.Execute();

            _controller.Verify(x => x.RestaurantDetails(It.IsAny<string>()), Times.AtLeastOnce);
        }

        [TestMethod]
        public void Execute_OnCall_RendersSecondView()
        {
            var action = new ViewRestaurantDetailsAction(_controller.Object, _inputOutput.Object);

            action.Execute();

            _controller.Verify(x => x.RestaurantDetails(It.IsAny<string>()).Render(), Times.AtLeastOnce);
        }
    }
}
