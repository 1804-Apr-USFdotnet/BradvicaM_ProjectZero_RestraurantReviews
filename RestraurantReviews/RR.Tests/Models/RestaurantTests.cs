using System;
using System.Collections.Generic;
using ApprovalTests;
using ApprovalTests.Reporters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RR.Models;

namespace RR.Tests.Models
{
    [TestClass]
    public class RestaurantTests
    {
        [TestMethod]
        [UseReporter(typeof(DiffReporter))]
        public void Restaurant_OnCall_DisplaysProperly()
        {
            var restaurant = new Restaurant
            {
                City = "Kansas City",
                State = "MO",
                Street = "123 Barbeque St.",
                ZipCode = 81721,
                Id = Guid.Empty,
                Name = "Billy Bobs Texas BBQ",
                PhoneNumber = "8761234121",
                AverageRating = 0.0,
                Website = "www.billybobs.com"
            };

            Approvals.Verify(restaurant);
        }

        [TestMethod]
        public void CalculateAverageRating_WhenPassedReviewList_ProperlyCalculatesRating()
        {
            var restaurant = new Restaurant();

            var reviews = new List<Review>
            {
                new Review
                {
                    Rating = 5.00
                },
                new Review
                {
                    Rating = 10.00
                },
                new Review
                {
                    Rating = 0.00
                }
            };

            restaurant.CalculateAverageRating(reviews);

            var result = restaurant.AverageRating;

            const double expected = 5.00;

            Assert.AreEqual(expected, result);
        }
    }
}
