using System;
using System.Collections.Generic;
using System.Linq;
using Library.Models;
using Library.QueryObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class RestaurantReviewsQueryTests
    {
        private List<Review> _reviews;
        private readonly Restaurant _restaurant;
        private readonly Guid _restaurantId;

        public RestaurantReviewsQueryTests()
        {
            _restaurantId = Guid.NewGuid();
            _restaurant = new Restaurant
            {
                Id = _restaurantId
            };
        }

        [TestMethod]
        public void AsExpression_OnQuery_ReturnsCorrectReviews()
        {
            var query = new RestaurantReviewsQuery(_restaurant);

            _reviews = new List<Review>
            {
                new Review{RestaurantId = _restaurantId},
                new Review{RestaurantId = Guid.NewGuid()}
            };

            var results = _reviews.AsQueryable().Where(query.AsExpression()).ToList();

            const int expected = 1;

            Assert.AreEqual(expected, results.Count);
        }
    }
}
