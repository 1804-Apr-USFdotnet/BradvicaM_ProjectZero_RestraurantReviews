using ApprovalTests;
using ApprovalTests.Reporters;
using Autofac;
using Console;
using Library.BusinessInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class RestaurantServiceTests
    {
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

                var results = service.SearchByString("Dirty");

                Approvals.VerifyAll(results, "Restaurants");
            }
        }
    }
}
