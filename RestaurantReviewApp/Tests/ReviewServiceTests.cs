using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ApprovalTests;
using ApprovalTests.Reporters;
using Autofac;
using Console;
using Library.BusinessInterfaces;
using Library.BusinessLogic;
using Library.Models;
using Library.RepositoryInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests
{
    [TestClass]
    public class ReviewServiceTests
    {
        private readonly Mock<IRestaurantRepository> _restaurantRepo;
        private readonly Mock<IReviewRepository> _reviewRepo;

        public ReviewServiceTests()
        {
            _restaurantRepo = new Mock<IRestaurantRepository>();
            _restaurantRepo.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(new Restaurant());
            _reviewRepo = new Mock<IReviewRepository>();
            _reviewRepo.Setup(x => x.Add(It.IsAny<Review>()));
            _reviewRepo.Setup(x => x.GetAll(It.IsAny<Expression<Func<Review, bool>>>())).Returns(new List<Review> { new Review() });
        }

        [TestMethod]
        [UseReporter(typeof(DiffReporter))]
        public void AllReviews_GivenARestaurant_ReturnsCorrectReviews()
        {
            using (var container = Bootstrapper.RegisterTypes())
            {
                var reviewService = container.Resolve<IReviewService>();
                var restaurantService = container.Resolve<IRestaurantService>();

                var restaurant = restaurantService.AllRestaurants().FirstOrDefault();

                var results = reviewService.AllReviews(restaurant);

                Approvals.VerifyAll(results, "Restaurant Reviews:");
            }
        }

        [TestMethod]
        public void AddReview_OnCall_CorrectlyAddReview()
        {
            var service = new ReviewService(_reviewRepo.Object, _restaurantRepo.Object);

            var review = new Review
            {
                Comment = "Ok",
                Id = Guid.NewGuid(),
                Restaurant = new Restaurant { Id = Guid.NewGuid() },
                Rating = 5.45,
                ReviewerName = "Mike"
            };

            service.AddReview(review);

            _reviewRepo.Verify(x => x.Add(It.IsAny<Review>()), Times.AtLeastOnce);
        }
    }
}
