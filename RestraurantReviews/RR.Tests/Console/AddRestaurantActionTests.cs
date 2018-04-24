using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RR.Console;
using RR.Console.Actions;
using RR.Console.Controllers;
using RR.Console.Views.Restaurant;
using RR.ViewModels;

namespace RR.Tests.Console
{
    [TestClass]
    public class AddRestaurantActionTests
    {
        private readonly Mock<IRestaurantController> _controller;
        private readonly Mock<IInputOutput> _inputOutput;

        public AddRestaurantActionTests()
        {
            _controller = new Mock<IRestaurantController>();
            _inputOutput = new Mock<IInputOutput>();

            _controller.Setup(x => x.InputAddRestaurant().Render());
            _controller.Setup(x => x.AddRestaurant(It.IsAny<AddRestaurantViewModel>()));
            _controller.Setup(x => x.AddRestaurant(It.IsAny<AddRestaurantViewModel>())).Returns(new AddRestuarantView());
            _controller.Setup(x => x.AddRestaurant(It.IsAny<AddRestaurantViewModel>()).Render());
            
        }

        [TestMethod]
        public void Execute_OnCall_ExecutesAction()
        {
            var action = new AddRestaurantAction(_controller.Object, _inputOutput.Object);

            action.Execute();

            _controller.Verify(x => x.AddRestaurant(It.IsAny<AddRestaurantViewModel>()), Times.AtLeastOnce);
        }

        [TestMethod]
        public void Execute_OnCall_ExecutesFirstView()
        {
            var action = new AddRestaurantAction(_controller.Object, _inputOutput.Object);

            action.Execute();

            _controller.Verify(x => x.InputAddRestaurant().Render(), Times.AtLeastOnce);
        }

        [TestMethod]
        public void Execute_OnAll_ExecutesSecondView()
        {
            var action = new AddRestaurantAction(_controller.Object, _inputOutput.Object);

            action.Execute();

            _controller.Verify(x => x.AddRestaurant(It.IsAny<AddRestaurantViewModel>()).Render(), Times.AtLeastOnce);
        }
    }
}
