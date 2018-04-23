using System;
using System.Collections.Generic;
using Library.Models;
using Library.QueryObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class SearchRestaurantQueryTests
    {
        private List<Restaurant> _restaurants;

        [TestMethod]
        public void AsExpression_Returns_RestaurntWithMatchingString()
        {
            const string queryValue = "bobby";

            var query = new SearchRestaurantQuery(queryValue);

            _restaurants = new List<Restaurant>
            {
                new Restaurant
                {
                    City = "Kansas City",
                    State = "MO",
                    Street = "123 Barbeque St.",
                    ZipCode = 81721,
                    Id = Guid.Empty,
                    Name = "Billy bobby Texas BBQ",
                    PhoneNumber = "8761234121",
                    AverageRating = 0.0,
                    Website = "www.billybobs.com"
                },
                new Restaurant
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
                }
            };

            var results = query.AsExpression(_restaurants);

            Assert.IsTrue(results.Count == 1);
        }

        [TestMethod]
        public void AsExpression_DoesNotReturn_RestaurantWithNoMatchingString()
        {
            const string queryValue = "MO";

            var query = new SearchRestaurantQuery(queryValue);

            _restaurants = new List<Restaurant>
            {
                new Restaurant
                {
                    City = "Kansas City",
                    State = "MO",
                    Street = "123 Barbeque St.",
                    ZipCode = 81721,
                    Id = Guid.Empty,
                    Name = "Billy johns Texas BBQ",
                    PhoneNumber = "8761234121",
                    AverageRating = 0.0,
                    Website = "www.billybobs.com"
                },
                new Restaurant
                {
                    City = "Kansas City",
                    State = "MO",
                    Street = "123 Barbeque St.",
                    ZipCode = 81721,
                    Id = Guid.Empty,
                    Name = "Billy bob Texas BBQ",
                    PhoneNumber = "8761234121",
                    AverageRating = 0.0,
                    Website = "www.billybobs.com"
                }
            };

            var results = query.AsExpression(_restaurants);

            Assert.IsTrue(results.Count == 2);
        }
    }
}
