using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RR.Console;
using RR.Console.Actions;
using RR.Console.Controllers;

namespace RR.Tests.Console
{
    [TestClass]
    public class DeleteRestaurantActionTests
    {
        private readonly Mock<IRestaurantController> _restaurantController;
        private readonly Mock<IInputOutput> _inputOutput;

        public DeleteRestaurantActionTests()
        {
            _restaurantController = new Mock<IRestaurantController>();
            _inputOutput = new Mock<IInputOutput>();

            _restaurantController.Setup(x => x.AllRestaurants().Render());
            _restaurantController.Setup(x => x.DeleteRestaurant(It.IsAny<string>()).Render());
        }

        [TestMethod]
        public void Execute_OnCall_RendersAllRestaurants()
        {
            var action = new DeleteRestaurantAction(_restaurantController.Object, _inputOutput.Object);

            action.Execute();

            _restaurantController.Verify(x => x.AllRestaurants().Render(), Times.AtLeastOnce);
        }

        [TestMethod]
        public void Execute_OnCall_CallDeleteMethod()
        {
            var action = new DeleteRestaurantAction(_restaurantController.Object, _inputOutput.Object);

            action.Execute();

            _restaurantController.Verify(x => x.DeleteRestaurant(It.IsAny<string>()), Times.AtLeastOnce);
        }

        [TestMethod]
        public void Execute_OnCall_RendersDeleteRestaurantComplete()
        {
            var action = new DeleteRestaurantAction(_restaurantController.Object, _inputOutput.Object);

            action.Execute();

            _restaurantController.Verify(x => x.DeleteRestaurant(It.IsAny<string>()).Render(), Times.AtLeastOnce);
        }
    }   
}
