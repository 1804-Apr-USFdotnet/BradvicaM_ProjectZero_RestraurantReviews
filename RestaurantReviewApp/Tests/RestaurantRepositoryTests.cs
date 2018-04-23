using System;
using System.Collections.Generic;
using System.Linq;
using Library.Models;
using Library.Repositories;
using Library.RepositoryInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests
{
    [TestClass]
    public class RestaurantRepositoryTests
    {
        private readonly Mock<IContext> _context;
        private readonly List<Restaurant> _restaurants;
        private readonly Guid _restaurantId;

        public RestaurantRepositoryTests()
        {
            _restaurantId = Guid.NewGuid();
            _restaurants = new List<Restaurant>
            {
                new Restaurant
                {
                    Id = _restaurantId
                }
            };
            _context = new Mock<IContext>();
            _context.Setup(x => x.Restaurants).Returns(_restaurants);
        }

        [TestMethod]
        public void GetById_Returns_CorrecctRestaurant()
        {
            var repo = new RestaurantRepository(_context.Object);

            var result = repo.GetById(_restaurantId);

            Assert.AreEqual(_restaurantId, result.Id);
        }

        [TestMethod]
        public void GetAll_Returns_AllRestaurants()
        {
            var repo = new RestaurantRepository(_context.Object);

            var result = repo.GetAll().ToList();

            var expected = _restaurants.Count;

            Assert.AreEqual(expected, result.Count);
        }
    }
}
