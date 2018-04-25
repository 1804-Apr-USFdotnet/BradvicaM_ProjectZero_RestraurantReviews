using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RR.Console.Actions;
using RR.Console.Controllers;
using RR.Console.Views.Restaurant;
using RR.ViewModels;

namespace RR.Tests.Console
{
    [TestClass]
    public class TopThreeRatedRestaurantsActionTests
    {
        private readonly Mock<IRestaurantController> _mock;

        public TopThreeRatedRestaurantsActionTests()
        {
            _mock = new Mock<IRestaurantController>();
            _mock.Setup(x => x.TopRatedRestaurants())
                .Returns(new TopRatedRestaurantsView(new List<TopRatedRestaurantViewModel>()));
            _mock.Setup(x => x.TopRatedRestaurants().Render());
        }

        [TestMethod]
        public void Execute_OnCall_ExecutesAction()
        {
            var action = new TopThreeRatedRestaurantsAction(_mock.Object);

            action.Execute();

            _mock.Verify(x => x.TopRatedRestaurants(), Times.AtLeastOnce); 
        }

        [TestMethod]
        public void Execute_OnCall_RendersViews()
        {
            var action = new TopThreeRatedRestaurantsAction(_mock.Object);

            action.Execute();

            _mock.Verify(x => x.TopRatedRestaurants().Render(), Times.AtLeastOnce);
        }
    }
}
