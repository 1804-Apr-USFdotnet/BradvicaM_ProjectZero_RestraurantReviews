using ApprovalTests;
using ApprovalTests.Reporters;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RR.Console;
using RR.DomainContracts;
using RR.DomainServices;
using RR.Models;
using RR.RepositoryContracts;

namespace RR.Tests.DomainServices
{
    [TestClass]
    public class RestaurantServiceTests
    {
        private readonly Mock<IRestaurantRepository> _mock;

        public RestaurantServiceTests()
        {
            _mock = new Mock<IRestaurantRepository>();
            _mock.Setup(x => x.Add(It.IsAny<Restaurant>()));
        }

        [TestMethod]
        [UseReporter(typeof(DiffReporter))]
        public void TopThreeRestaurantByAverageReview_Returns_CorrectRestaurants()
        {
            using (var container = Bootstrapper.RegisterTypes())
            {
                var service = container.Resolve<IRestaurantService>();

                var results = service.TopThreeRestaurantByAverageReview();

                Approvals.VerifyAll(results, "Restaurants");
            }
        }

        [TestMethod]
        [UseReporter(typeof(DiffReporter))]
        public void AllRestaurants_Returns_AllRestaurantsFromDatabase()
        {
            using (var container = Bootstrapper.RegisterTypes())
            {
                var service = container.Resolve<IRestaurantService>();

                var results = service.AllRestaurants();

                Approvals.VerifyAll(results, "Restaurants");
            }
        }

        [TestMethod]
        [UseReporter(typeof(DiffReporter))]
        public void SearchByString_Returns_AllRestaurantsThatContainStringValue()
        {
            using (var container = Bootstrapper.RegisterTypes())
            {
                var service = container.Resolve<IRestaurantService>();

                var results = service.SearchAll("Jordan");

                Approvals.VerifyAll(results, "Restaurants");
            }
        }

        [TestMethod]
        public void AddRestaurant_Correctly_AddsRestuarantToDatabase()
        {
            var service = new RestaurantService(_mock.Object);

            var resturant = new Restaurant();

            service.AddRestaurant(resturant);

            _mock.Verify(x => x.Add(It.IsAny<Restaurant>()), Times.AtLeastOnce);
        }

        [TestMethod]
        [UseReporter(typeof(DiffReporter))]
        public void SearchByName_GivenString_ReturnsCorrectRestaurant()
        {
            using (var container = Bootstrapper.RegisterTypes())
            {
                var service = container.Resolve<IRestaurantService>();

                var result = service.SearchByName("Billy Bobs Texas BBQ");

                Approvals.Verify(result);
            }
        }
    }
}
