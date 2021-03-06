﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
    public class ReviewServiceTests
    {
        private readonly Mock<IRestaurantRepository> _restaurantRepo;
        private readonly Mock<IReviewRepository> _reviewRepo;

        public ReviewServiceTests()
        {
            _restaurantRepo = new Mock<IRestaurantRepository>();
            _restaurantRepo.Setup(x => x.GetByName(It.IsAny<string>())).Returns(new Restaurant{Reviews = new List<Review>{new Review()}});
            _reviewRepo = new Mock<IReviewRepository>();
            _reviewRepo.Setup(x => x.Add(It.IsAny<Review>()));
            _reviewRepo.Setup(x => x.Update(It.IsAny<Review>()));
            _reviewRepo.Setup(x => x.Delete(It.IsAny<Review>()));
            _reviewRepo.Setup(x => x.GetAll(It.IsAny<Expression<Func<Review, bool>>>())).Returns(new List<Review>{new Review()});
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
                ReviewId = Guid.NewGuid(),
                Restaurant = new Restaurant { RestaurantId = Guid.NewGuid(), Name = "jimmies"},
                Rating = 5.45,
                ReviewerName = "Mike"
            };

            service.AddReview(review);

            _reviewRepo.Verify(x => x.Add(It.IsAny<Review>()), Times.AtLeastOnce);
        }

        [TestMethod]
        public void UpdateReview_GivenReview_CallsUpdate()
        {
            var service = new ReviewService(_reviewRepo.Object, _restaurantRepo.Object);

            service.UpdateReview(new Review());

            _reviewRepo.Verify(x => x.Update(It.IsAny<Review>()), Times.AtLeastOnce);
        }

        [TestMethod]
        [UseReporter(typeof(DiffReporter))]
        public void GetByIndentifcation_GivenId_ReturnsCorrectReview()
        {
            using (var container = Bootstrapper.RegisterTypes())
            {
                var reviewService = container.Resolve<IReviewService>();

                var result = reviewService.GetByIdentification(1);

                Approvals.Verify(result);
            }
        }

        [TestMethod]
        public void DeleteReview_GivenReview_CallsDeleteMethod()
        {
            var service = new ReviewService(_reviewRepo.Object, _restaurantRepo.Object);

            service.DeleteReview(new Review());

            _reviewRepo.Verify(x => x.Delete(It.IsAny<Review>()), Times.AtLeastOnce);
        }
    }
}
