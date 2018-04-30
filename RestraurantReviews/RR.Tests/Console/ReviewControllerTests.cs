using System.Collections.Generic;
using Autofac;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RR.Console;
using RR.Console.Controllers;
using RR.Console.Views.Review;
using RR.DomainContracts;
using RR.Models;
using RR.ViewModels;

namespace RR.Tests.Console
{
    [TestClass]
    public class ReviewControllerTests
    {
        private readonly IContainer _container;
        private readonly Mock<IReviewService> _reviewService;
        private readonly Mock<IRestaurantService> _restaurantService;

        public ReviewControllerTests()
        {
            _container = Bootstrapper.RegisterTypes();
            _reviewService = new Mock<IReviewService>();
            _restaurantService = new Mock<IRestaurantService>();
            _reviewService.Setup(x => x.AddReview(It.IsAny<Review>()));
            _reviewService.Setup(x => x.GetByIdentification(It.IsAny<int>())).Returns(new Review{Restaurant = new Restaurant{Reviews = new List<Review>{new Review()}}});
            _reviewService.Setup(x => x.UpdateReview(It.IsAny<Review>()));
            _restaurantService.Setup(x => x.UpdateRestaurant(It.IsAny<Restaurant>()));
            _reviewService.Setup(x => x.DeleteReview(It.IsAny<Review>()));
            _reviewService.Setup(x => x.AllReviews(It.IsAny<Restaurant>())).Returns(new List<Review>{new Review()});
            
            _restaurantService.Setup(x => x.SearchByName(It.IsAny<string>())).Returns(new Restaurant());
        }

        [TestMethod]
        public void AddReview_Returns_CorrectView()
        {
            var controller = new ReviewController(_reviewService.Object, _container.Resolve<IMapper>(), _restaurantService.Object);

            var result = controller.AddReview(new AddReviewViewModel());

            Assert.IsInstanceOfType(result, typeof(AddReviewView));
        }

        [TestMethod]
        public void InputAddReview_Returns_CorrectView()
        {
            using (var container = Bootstrapper.RegisterTypes())
            {
                var controller = container.Resolve<IReviewController>();

                var result = controller.InputAddReview();

                Assert.IsInstanceOfType(result, typeof(InputAddReviewView));
            }
        }

        [TestMethod]
        public void RestaurantReviews_Returns_CorrectView()
        {
            var controller = new ReviewController(_reviewService.Object, _container.Resolve<IMapper>(), _restaurantService.Object);

            var result = controller.RestaurantReviews("Omba");

            Assert.IsInstanceOfType(result, typeof(RestaurantReviewsView));
        }

        [TestMethod]
        public void InputUpdateReview_Returns_CorrectView()
        {
            var controller = new ReviewController(_reviewService.Object, _container.Resolve<IMapper>(), _restaurantService.Object);

            var result = controller.InputUpdateReview();

            Assert.IsInstanceOfType(result, typeof(InputUpdateReviewView));
        }

        [TestMethod]
        public void UpdateReview_Returns_CorrectView()
        {
            var controller = new ReviewController(_reviewService.Object, _container.Resolve<IMapper>(), _restaurantService.Object);

            var result = controller.UpdateReview(new UpdateReviewViewModel());

            Assert.IsInstanceOfType(result, typeof(UpdateReviewView));
        }

        [TestMethod]
        public void InputDeleteReview_ReturnsCorrectView()
        {
            var controller = new ReviewController(_reviewService.Object, _container.Resolve<IMapper>(), _restaurantService.Object);

            var result = controller.InputDeleteReview();

            Assert.IsInstanceOfType(result, typeof(InputDeleteReviewView));
        }

        [TestMethod]
        public void DeleteReview_ReturnsCorrectView()
        {
            var controller = new ReviewController(_reviewService.Object, _container.Resolve<IMapper>(), _restaurantService.Object);

            var result = controller.DeleteReview(1);

            Assert.IsInstanceOfType(result, typeof(DeleteReviewView));
        }
    }
}
