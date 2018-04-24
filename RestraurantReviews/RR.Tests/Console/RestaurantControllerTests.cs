using Autofac;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RR.Console;
using RR.Console.Controllers;
using RR.Console.Views.Restaurant;
using RR.Console.Views.Review;
using RR.DomainContracts;
using RR.ViewModels;

namespace RR.Tests.Console
{
    [TestClass]
    public class RestaurantControllerTests
    {
        private readonly Mock<IRestaurantService> _service;
        private readonly Mock<IMapper> _mapper;

        public RestaurantControllerTests()
        {
            _service = new Mock<IRestaurantService>();
            _mapper = new Mock<IMapper>();
        }

        [TestMethod]
        public void InputAddRestaurant_Returns_CorrectView()
        {
            var controller = new RestaurantController(_service.Object, _mapper.Object);

            var result = controller.InputAddRestaurant();

            Assert.IsInstanceOfType(result, typeof(InputAddRestaurantView));
        }

        [TestMethod]
        public void AddRestaurant_Returns_CorrectView()
        {
            var controller = new RestaurantController(_service.Object, _mapper.Object);

            var result = controller.AddRestaurant(new AddRestaurantViewModel());

            Assert.IsInstanceOfType(result, typeof(AddRestuarantView));
        }

        [TestMethod]
        public void InputViewRestaurantsFilter_Returns_CorrectView()
        {
            var controller = new RestaurantController(_service.Object, _mapper.Object);

            var result = controller.InputViewRestaurantsFilter();

            Assert.IsInstanceOfType(result, typeof(InputViewRestaurantsFilterView));
        }

        [TestMethod]
        public void AllRestaurants_GivenParameterReturns_CorrectView()
        {
            using (var container = Bootstrapper.RegisterTypes())
            {
                var controller = container.Resolve<IRestaurantController>();

                var result = controller.AllRestaurants("blah");

                Assert.IsInstanceOfType(result, typeof(AllRestaurantsView));
            }    
        }

        [TestMethod]
        public void AllRestaurants_Returns_CorrectView()
        {
            using (var container = Bootstrapper.RegisterTypes())
            {
                var controller = container.Resolve<IRestaurantController>();

                var result = controller.AllRestaurants();

                Assert.IsInstanceOfType(result, typeof(AllRestaurantsView));
            }
        }

        [TestMethod]
        public void TopRatedRestaurants_Returns_CorrectView()
        {
            using (var container = Bootstrapper.RegisterTypes())
            {
                var controller = container.Resolve<IRestaurantController>();

                var result = controller.TopRatedRestaurants();

                Assert.IsInstanceOfType(result, typeof(TopRatedRestaurantsView));
            }
        }

        [TestMethod]
        public void RestaurantDetails_Returns_CorrectView()
        {
            var controller = new RestaurantController(_service.Object, _mapper.Object);

            var result = controller.RestaurantDetails("Elba");

            Assert.IsInstanceOfType(result, typeof(RestaurantDetailsView));
        }

        [TestMethod]
        public void SearchForEntity_Returns_CorrectView()
        {
            using (var container = Bootstrapper.RegisterTypes())
            {
                var controller = container.Resolve<IRestaurantController>();

                var result = controller.SearchForEntity("Elba");

                Assert.IsInstanceOfType(result, typeof(SearchForEntityView));
            }
        }

        [TestMethod]
        public void InputRestaurantName_Returns_CorrectView()
        {
            var controller = new RestaurantController(_service.Object, _mapper.Object);

            var result = controller.InputRestaurantName();

            Assert.IsInstanceOfType(result, typeof(InputRestaurantNameView));
        }

        [TestMethod]
        public void InputSearchTerm_Returns_CorrectView()
        {
            var controller = new RestaurantController(_service.Object, _mapper.Object);

            var result = controller.InputSearchTerm();

            Assert.IsInstanceOfType(result, typeof(InputSearchTermView));
        }
    }
}
