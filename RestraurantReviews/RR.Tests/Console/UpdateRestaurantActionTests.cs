using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RR.Console;
using RR.Console.Actions;
using RR.Console.Controllers;
using RR.ViewModels;

namespace RR.Tests.Console
{
    [TestClass]
    public class UpdateRestaurantActionTests
    {
        private readonly Mock<IRestaurantController> _restaurantController;
        private readonly Mock<IInputOutput> _inputOutput;

        public UpdateRestaurantActionTests()
        {
            _restaurantController = new Mock<IRestaurantController>();
            _inputOutput = new Mock<IInputOutput>();

            _restaurantController.Setup(x => x.AllRestaurants().Render());
            _restaurantController.Setup(x => x.InputAddUpdateRestaurant().Render());
            _restaurantController.Setup(x =>
                x.UpdateRestaurant(It.IsAny<string>(), It.IsAny<UpdateRestaurantViewModel>()).Render());
        }

        [TestMethod]
        public void Execute_OnCall_RendersFirstView()
        {
            var action = new UpdateRestaurantAction(_restaurantController.Object, _inputOutput.Object);

            action.Execute();

            _restaurantController.Verify(x => x.AllRestaurants().Render(), Times.AtLeastOnce);
        }

        [TestMethod]
        public void Execute_OnCall_RendersSecondView()
        {
            var action = new UpdateRestaurantAction(_restaurantController.Object, _inputOutput.Object);

            action.Execute();

            _restaurantController.Verify(x => x.InputAddUpdateRestaurant().Render(), Times.AtLeastOnce);
        }

        [TestMethod]
        public void Execute_OnCall_CallsUpdateRestaurant()
        {
            var action = new UpdateRestaurantAction(_restaurantController.Object, _inputOutput.Object);

            action.Execute();

            _restaurantController.Verify(x => x.UpdateRestaurant(It.IsAny<string>(), It.IsAny<UpdateRestaurantViewModel>()), Times.AtLeastOnce);
        }

        [TestMethod]
        public void Execute_OnCall_RendersThirtView()
        {
            var action = new UpdateRestaurantAction(_restaurantController.Object, _inputOutput.Object);

            action.Execute();

            _restaurantController.Verify(x => x.UpdateRestaurant(It.IsAny<string>(), It.IsAny<UpdateRestaurantViewModel>()).Render(), Times.AtLeastOnce);
        }
    }
}
